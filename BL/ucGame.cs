using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Xml.Linq;
using System.IO;
using System.Threading;

namespace BL
{
    //1. הצהרה על דלגט
    public delegate void dComputerFinishedEventHandler(List<List<ccCard>> cards);

    public delegate void dLoadChangesFinishedEventHandler(string filePath); 

    public partial class ucGame : UserControl
    {
        public ucPlayerBoard[] playersBoards;
        public List<List<ccCard>> cloneMainBoard=new List<List<ccCard>>(), mainBoard=new List<List<ccCard>>();
        public List<ccCard> box = new List<ccCard>();
        public int turn;
        public int numOfPlayers;
        public Random r=new Random();
        public ucPlayerBoard currentPlayer;
        public ucPlayerBoard clonePlayerBoard;

        public string path;
        public bool netWorkGame = false; 
        public bool NewPlayerNetwork;
        public string currentPlayerName;
        public bool PlayerClosed = false;

        public byte[,] checkMat;
        public List<List<ccCard>> BestBoard = new List<List<ccCard>> { };
        public int maxScore = 0;
        public byte joker_cnt = 0;
        public byte must_joker_cnt = 0;
        //2. הגדרת אוונט מסוג הדלגט
        public event dComputerFinishedEventHandler eComputerFinished;
        public event dLoadChangesFinishedEventHandler eLoadChangesFinished; 
        Audio a = new Audio();
        public List<List<ccCard>> cmainBoard;
        public List<List<ccCard>> arrangedBoard=new List<List<ccCard>>();

        public List<Point> Seriaslocation = new List<Point> { }; // עבור רשת

        public List<List<ccCard>> OptionalsSerias = new List<List<ccCard>>();

        public ucGame(int _numOfPlayers, List<string> name, List<bool> kindPlayer, bool networkGame,string currUserName)//ekindCard kind,אמור לקבל גם:
        {
            InitializeComponent();
           // Play_Computer();
            numOfPlayers = _numOfPlayers;
            #region אתחול כרטיסים בקופסה
            
            ccCard tempCard;
            byte k,j;
            for(int i=0; i<4 ; i++)
            {
                for (j = 0; j < 2; j++)//פעמיים כל צבע
                    for (k = 1; k < 14; k++)
                    {
                        tempCard = new ccCard(k, (eColor)i);
                        tempCard.Status = eStatus.Box;
                        box.Add(tempCard);                        
                    }
                tempCard = new ccCard(14,(eColor)i);
                tempCard.Status = eStatus.Box;
                box.Add(tempCard);//joker   

            }
            #endregion
            currentPlayerName = currUserName;
            #region אתחול כרטיסים בלוחות השחקנים
            playersBoards = new ucPlayerBoard[numOfPlayers];
            int rand;
            for (int i = 0; i < numOfPlayers; i++)
            {
                
                List<ccCard> tempList=new List<ccCard>();   
                for (j = 0; j < 14; j++)
                {
                    bool flRet;
                    do
                    {
                        flRet = false;
                        rand=r.Next(107);
                        if(box[rand].Status!=eStatus.Box)
                            flRet=true;
                        if (!netWorkGame && box[rand].Number == 14)
                            flRet = true;
                    } while (flRet);
                    box[rand].Status = eStatus.Player;
                    tempList.Add(box[rand]);
                }
                playersBoards[i] = new ucPlayerBoard(tempList,name[i],kindPlayer[i]);
            }
            #endregion
            //הגרלת תור
            do
            {
                turn = r.Next(numOfPlayers);
            } while (playersBoards[turn].computer);


            #region network2 //@@
            netWorkGame = networkGame;

            if (netWorkGame)
            {

                int drive = Microsoft.VisualBasic.FileIO.FileSystem.Drives.Count;
                int i;
                for (i = 0; i < drive; i++)
                {
                    if (Microsoft.VisualBasic.FileIO.FileSystem.Drives[i].DriveType == DriveType.Removable)
                    {
                        path = Microsoft.VisualBasic.FileIO.FileSystem.Drives[i].Name;
                        break;
                    }
                }


                if (File.Exists(path + name[0] + name[1] + ".xml"))
                {

                    NewPlayerNetwork = false; // האם זה שחקן מצטרף או חדש- כרגע מצטרף
                    PlayerClosed = false;

                    try
                    {

                       // LoadUcGame(path + name[0] + name[1]);
                        mainBoard.Clear();
                        LoadUcGameFirst(path + name[0] + name[1]);

                        //עבור טעינת מיקומי הפאנלים formGame - זריקת ארוע ל 
                        if (eLoadChangesFinished != null)
                            eLoadChangesFinished(path + name[0] + name[1]);

                        File.Delete(path + name[0] + name[1] + ".xml");
                        
                        //ChangeTurn();
                    }
                    
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                }
                else
                {
                    NewPlayerNetwork = true;
                    saveStatusNetwork();
                }
            }
            fswNetork.Path = path;
            //*********************************************

            #endregion
            MessageBox.Show("." + playersBoards[turn].name + " random to play first ", "Rammi-start game", MessageBoxButtons.OK, MessageBoxIcon.Information);//@@
            if(netWorkGame)
            {
                if (playersBoards[0].name == currentPlayerName)
                    Show_Cards(0);
                else
                    Show_Cards(1);
            }
            else
                Show_Cards(turn);


            play();
            //check();
             if(currentPlayerName != playersBoards[turn].name)
                timer1.Start();
            
        }

        private void LoadUcGameFirst(string folderPath)//###
        {
            eColor tmpec = new eColor();
            eStatus tmpes = new eStatus();
            string curName;
            List<ccCard> curCards = new List<ccCard> { };
            //InitializNamesAttrib();
            // מתוך הנחה שמדובר במקסימום 2 שחקנים אז התור הקודם הוא או 1 או 0
            int beforeTurn = turn == 0 ? 1 : 0;

            //XDocument doc = XDocument.Load(path + "\\" + folderPath + "\\lastGame.xml");// לא בטוח טוב
            XDocument doc = XDocument.Load(folderPath + ".xml");
            var prop = doc.Element("properties");
            // שליפת התור הנוכחי
            turn = (int)prop.Attribute("turn");

            // שליפת אבני הקופה
            box.Clear();  //ריקון אבני הקופה כדי לאתחלה לפי המשחק השמור
            foreach (XElement crd in prop.Element("box").Elements())
            {
                int curNum = (int)crd.Attribute("number");
                string curColor = (string)crd.Attribute("color");
                string stt = (string)crd.Attribute("status");
                tmpec = ToEColor(curColor);
                tmpes = ToEStatus(stt);
                box.Add(new ccCard((byte)curNum, tmpec, tmpes));

            }
            // שליפת מאפייני השחקנים ואבניהם
            for (int i = 0; i < numOfPlayers; i++)
            {

                curName = (string)prop.Element("player" + (i + 1)).Attribute("name");
                
                var curPlyr = prop.Element("player" + (i + 1));
                //ריקון רשימת הקלפים של השחקן כדי לאתחלה לפי המשחק השמור
                playersBoards[i].listCards.Clear();
                curCards.Clear();
                for (int j = 0; j < (int)curPlyr.Attribute("cntCard"); j++)
                {
                    int curNum = (int)curPlyr.Element("card" + (j + 1)).Attribute("number");
                    string curColor = (string)curPlyr.Element("card" + (j + 1)).Attribute("color");
                    tmpec = ToEColor(curColor);
                    curCards.Add(new ccCard((byte)curNum, tmpec));
                }
                playersBoards[i] = new ucPlayerBoard(curCards.ToList(), curName, false);
            }
            // שליפת לוח המשחק
            if (mainBoard.Count > 0)
                mainBoard.Clear(); //ריקון לוח המשחק כדי לאתחלה לפי המשחק השמור
            else
                mainBoard = new List<List<ccCard>> { };
            foreach (XElement seria in prop.Element("mainBoard").Elements())
            {
                List<ccCard> tmp = new List<ccCard> { };
                int i = 0;

                foreach (XElement crd in seria.Elements())
                {
                    int curNum = (int)crd.Attribute("number");
                    string curColor = (string)crd.Attribute("color");
                    string stt = (string)crd.Attribute("status");
                    tmpec = ToEColor(curColor);
                    tmpes = ToEStatus(stt);
                    tmp.Add(new ccCard((byte)curNum, tmpec, tmpes));
                }
                mainBoard.Add(tmp);
                i++;
            }
            //Show_Cards();
        }
        public void LoadUcGame(string folderPath)
        {


            eColor tmpec = new eColor();
            eStatus tmpes = new eStatus();

            List<ccCard> curCards = new List<ccCard> { };
            //InitializNamesAttrib();
            // מתוך הנחה שמדובר במקסימום 2 שחקנים אז התור הקודם הוא או 1 או 0
            int beforeTurn = turn == 0 ? 1 : 0;

            //XDocument doc = XDocument.Load(path + "\\" + folderPath + "\\lastGame.xml");// לא בטוח טוב
            XDocument doc = XDocument.Load(folderPath + ".xml");
            var prop = doc.Element("properties");

            // שליפת התור הנוכחי
            turn = (int)prop.Attribute("turn");

            // שליפת אבני הקופה
            box.Clear();  //ריקון אבני הקופה כדי לאתחלה לפי המשחק השמור
            foreach (XElement crd in prop.Element("box").Elements())
            {
                int curNum = (int)crd.Attribute("number");
                string curColor = (string)crd.Attribute("color");
                string stt = (string)crd.Attribute("status");
                tmpec = ToEColor(curColor);
                tmpes = ToEStatus(stt);
                box.Add(new ccCard((byte)curNum, tmpec, tmpes));

            }

            // שליפת לוח המשחק
            if (mainBoard.Count > 0)
                mainBoard.Clear(); //ריקון לוח המשחק כדי לאתחלה לפי המשחק השמור
            else
                mainBoard = new List<List<ccCard>> { };
            foreach (XElement seria in prop.Element("mainBoard").Elements())
            {
                List<ccCard> tmp = new List<ccCard> { };
                int i = 0;

                foreach (XElement crd in seria.Elements())
                {
                    int curNum = (int)crd.Attribute("number");
                    string curColor = (string)crd.Attribute("color");
                    string stt = (string)crd.Attribute("status");
                    tmpec = ToEColor(curColor);
                    tmpes = ToEStatus(stt);
                    tmp.Add(new ccCard((byte)curNum, tmpec, tmpes));
                }
                mainBoard.Add(tmp);
                i++;
            }
            //Show_Cards();


        }
        public void startPlayNetwork(int _turn) 
        {
            turn = _turn;
            //if(currentPlayerName != playersBoards[turn].name)
            //    timer1.Start();
        }
        public ucGame()
        {
            InitializeComponent();
        }
        public void check()
        {
            cmainBoard = new List<List<ccCard>> { };
            //check
            List<ccCard> c = new List<ccCard> { };
            List<ccCard> c1 = new List<ccCard> { };
            //c.Add(new ccCard(3, eColor.Blue));
            c.Add(new ccCard(12, eColor.Red));
            c.Add(new ccCard(14, eColor.Green));
            c.Add(new ccCard(12, eColor.Green));
           // c.Add(new ccCard(7, eColor.Blue));
            cmainBoard.Add(c);

            //c1.Add(new ccCard(3, eColor.Blue));
            //c1.Add(new ccCard(3, eColor.Green));
            //c1.Add(new ccCard(3, eColor.Red));
            //cmainBoard.Add(c1);
            //cmainBoard[0].Add(new ccCard(3, eColor.Blue));
            //cmainBoard[0].Add(new ccCard(3, eColor.Red));
            //cmainBoard[0].Add(new ccCard(3, eColor.Yellow));

            //cmainBoard[1].Add(new ccCard(3, eColor.Yellow));
            //cmainBoard[1].Add(new ccCard(4, eColor.Yellow));
            //cmainBoard[1].Add(new ccCard(5, eColor.Yellow));
            //cmainBoard[1].Add(new ccCard(6, eColor.Yellow));
            //cmainBoard[1].Add(new ccCard(7, eColor.Yellow));

            //cmainBoard[1].Add(new ccCard(1, eColor.Red));
            //cmainBoard[1].Add(new ccCard(14, eColor.Red));
            //cmainBoard[1].Add(new ccCard(3, eColor.Red));

            if (legal(cmainBoard))
                MessageBox.Show("Good Sidra!!!");
            else
                MessageBox.Show("Bad Sidra!!!");
        }

        public List<List<ccCard>> endTurn(List<List<ccCard>> checkMainBoard, List<ccCard> _currentPlayer)
        {
            if (legal(checkMainBoard))
            {
                //MessageBox.Show("יצרת סדרות חוקיות");
                //עדכון מצב הכרטיסים הנכון
                for (int i = 0; i < checkMainBoard.Count; i++)
                   foreach (ccCard card in checkMainBoard[i])
                        if (card.Status==eStatus.Player)
                           card.Status = eStatus.mainBoard;
                
                //עדכוני הליסטים
                mainBoard = checkMainBoard;
                playersBoards[turn].listCards = _currentPlayer;
            }

            else 
            {
                
                a.Play(RammyCube.Properties.Resources.Speech_Off, Microsoft.VisualBasic.AudioPlayMode.Background);   
                //יש לעדכן את הפאנלים בליסטים השמורים
                MessageBox.Show("invalid serias!");
                mainBoard = cloneMainBoard.ToList();
            }
            if (netWorkGame)//@@
            {
                //@@ שמירת מצב נוכחי עבור משחק ברשת
                saveStatusNetwork();
                ChangeTurn();
                //###Show_Cards();
                MessageBox.Show(playersBoards[turn].name + " it is your turn to play "); //TODO: !לוודא שאכן מודיע לשני השחקנים על התור הנכון
                play();
                if (currentPlayerName != playersBoards[turn].name)
                {
                    timer1.Start();
                    //ChangeTurn();
                }
                
            }
            
            else//@@
            {

                ChangeTurn();

                if (playersBoards[turn].computer)
                    Play_Computer();
                else
                {
                   
                    if (playersBoards[0].name == currentPlayerName)
                        Show_Cards(0);
                    else
                        Show_Cards(1);
                    MessageBox.Show(playersBoards[turn].name + "  it is your turn to play ");
                    play();
                }
            }

            return mainBoard;
            
        }
        public void saveStatusNetwork()//###
        {
            XElement prop = new XElement(
                 new XElement("properties", new XAttribute("numOfPlayers", numOfPlayers), new XAttribute("turn", turn)));


            for (int i = 0; i < numOfPlayers; i++)
            {
                int j;
                XElement plyrs = new XElement("player" + (i + 1).ToString(),
                    new XAttribute("name", playersBoards[i].name));

                for (j = 0; j < playersBoards[i].listCards.Count; j++)
                {
                    plyrs.Add(new XElement("card" + (j + 1).ToString(),
                        new XAttribute("number", playersBoards[i].listCards[j].Number), new XAttribute("color", playersBoards[i].listCards[j].getColor)));

                }
                plyrs.Add(new XAttribute("cntCard", j));
                prop.Add(plyrs);
            }




            XElement xbox = new XElement("box");
            for (int i = 0; i < box.Count; i++)
            {
                xbox.Add(new XElement("card" + (i + 1).ToString(),
                     new XAttribute("number", box[i].Number), new XAttribute("color", box[i].getColor), new XAttribute("status", box[i].Status)));

            }
            prop.Add(xbox);

            XElement series = new XElement("mainBoard");
            for (int i = 0; i < mainBoard.Count; i++)
            {
                XElement seria = new XElement("seria" + (i + 1).ToString(),
                    new XAttribute("x", Seriaslocation[i].X), new XAttribute("y", Seriaslocation[i].Y));
                for (int j = 0; j < mainBoard[i].Count; j++)
                {
                    seria.Add(new XElement("card" + (j + 1).ToString(),
                     new XAttribute("number", mainBoard[i][j].Number), new XAttribute("color", mainBoard[i][j].getColor), new XAttribute("status", mainBoard[i][j].Status)));
                }
                series.Add(seria);
            }

            prop.Add(series);

            //prop.Save(playersBoards[turn].name + "\\lastGame.xml");
            prop.Save(path + playersBoards[0].name + playersBoards[1].name + ".xml");
        }
        public void initalizeLocations(List<Point> _Seriaslocation)
        {
            Seriaslocation = _Seriaslocation;
        }
        private void ChangeTurn()
        {
            //לקיחת קלף מהקופה
            int rand;
            //בדיקה אם קימים קלפים בקופה
            if (BoxNotEmpty())
            {
                bool flRet;
               
                do
                {
                    flRet = false;
                    rand = r.Next(box.Count());
                    if (box[rand].Status != eStatus.Box)
                        flRet = true;
                    if (!netWorkGame && box[rand].Number == 14)
                        flRet = true;
                } while (flRet);
                box[rand].Status = eStatus.Player;
                playersBoards[turn].listCards.Add(box[rand]);
            }
            else
                MessageBox.Show("!!הקלפים בקופה אזלו");
            //בדיקה אם המשחק הסתיים
            if (CheckGameFinished(playersBoards[turn].listCards))
            {
                a.Play(RammyCube.Properties.Resources.Boo, Microsoft.VisualBasic.AudioPlayMode.Background);   
                MessageBox.Show("המשחק נגמר", playersBoards[turn].name+" !!ניצחת!  כל הכבוד");        
           
               
            }
            else
            {
                Show_Cards(turn);//###
                //מעבר תור
                turn++;
                if (turn == numOfPlayers)
                    turn = 0;
               
            }
        }

        public bool BoxNotEmpty()
        {
            if (box.Count == 0)
                return false;
            return true;
        }

        public bool CheckGameFinished(List<ccCard> listcards)
        {
            if (listcards.Count == 0)
                return true;
            return false;
        }
        public eColor ToEColor(string colorToParse)
        {
            eColor retColor = new eColor();
            switch (colorToParse)
            {
                case "Blue":
                    retColor = eColor.Blue;
                    break;
                case "Red":
                    retColor = eColor.Red;
                    break;
                case "Green":
                    retColor = eColor.Green;
                    break;
                case "Orange":
                    retColor = eColor.Orange;
                    break;
            }
            return retColor;
        }
         public eStatus ToEStatus(string statusToParse)
        {
            eStatus retStatus = new eStatus();
            switch (statusToParse)
            {
                case "Box":
                    retStatus = eStatus.Box;
                    break;
                case "mainBoard":
                    retStatus = eStatus.mainBoard;
                    break;
                case "Player":
                    retStatus = eStatus.Player;
                    break;
                          }
            return retStatus;
        }
        public void Show_Cards(int index)
        {
            int top = 0, left = ccCard.l_space_between_cards*3;
           // if (playersBoards[turn].name == "אני")
            {

                foreach (ccCard card in playersBoards[index].listCards)
                {
                    //הצגת הכרטיסים על המסך
                    if (card.Width != ccCard.width_card)
                    {
                        card.Width = ccCard.width_card;
                        card.Height = ccCard.height_card;
                        card.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    }
                    card.Top = top;
                    card.Left = left;

                    if (card.Left + ccCard.width_card > playersBoards[index].Width)
                    {
                        top += card.Height;
                        left = ccCard.l_space_between_cards*3;
                    }
                    card.Top = top;
                    card.Left = left;

                    left += card.Width + ccCard.l_space_between_cards;
                    card.Show();
                    card.BringToFront();
                    playersBoards[index].Controls.Add(card);
                }

            }
        }

        public void play()
        {
            
            //עבור שחקן רגיל           
            //שכפול לוח המשחק של השחקן
            cloneMainBoard.Clear();
            clonePlayerBoard = (ucPlayerBoard) playersBoards[turn].Clone();
            List<ccCard> temp = new List<ccCard> { };
                        for (int i = 0; i < mainBoard.Count; i++)
            {
             
                foreach (ccCard c in mainBoard[i])
                {
                    temp.Add(c);
                }
                cloneMainBoard.Add(temp.ToList());
                temp.Clear();
            }

            if (playersBoards[turn].computer == true)
            {
               // MessageBox.Show("Wait");
                Play_Computer();
            }
           
        }

        public void Play_Computer()
        {
            joker_cnt = 0;
            must_joker_cnt = 0;
            
            #region //check
            List<ccCard> c = new List<ccCard> { };
            
           
            
            c.Add(new ccCard(1, eColor.Green));
            c.Add(new ccCard(2, eColor.Green));
            c.Add(new ccCard(3, eColor.Green));

           

            c.Add(new ccCard(3, eColor.Blue));
            //c.Add(new ccCard(3, eColor.Green));
            c.Add(new ccCard(3, eColor.Red));
            
            
            c.Add(new ccCard(2, eColor.Blue));
            //c.Add(new ccCard(2, eColor.Green));
            c.Add(new ccCard(2, eColor.Orange));


            c.Add(new ccCard(7, eColor.Red));
            c.Add(new ccCard(8, eColor.Red));
            c.Add(new ccCard(9, eColor.Red));

            c.Add(new ccCard(6, eColor.Blue));
            c.Add(new ccCard(6, eColor.Green));
            c.Add(new ccCard(6, eColor.Orange));

            c.Add(new ccCard(6, eColor.Green));
            c.Add(new ccCard(7, eColor.Green));
            c.Add(new ccCard(8, eColor.Green));
            #endregion

            // בניית רשימת הקלפים לבדיקה- שרשור של קלפי השחקן עם קלפי הסדרות הקיימות
            List<ccCard> listToCheck=playersBoards[turn].listCards.ToList();
            foreach (List<ccCard> curLst in mainBoard)
	        {
                foreach (ccCard curCrd in curLst)
                {
                    listToCheck.Add(curCrd);
                }		         
	        }
            
            // קריאה לפונקציה הבונה את המטריצה לבדיקה
            checkMat = BuildMat(listToCheck);
            //checkMat = BuildMat(c);
            
            #region אתחול הסדרות האפשריות
            int count1, count2, j;
            List<ccCard> tempSeria1 = new List<ccCard>(), tempSeria2 = new List<ccCard>();

            //לכיוון למטה
            for (int i = 0; i < 4; i++)
            {

                for (j = 0; j < 13; j++)
                {
                    while (j < 13 && checkMat[j, i] == 0) { j++; }
                    count1 = 0;
                    count2 = 0;
                    while (j < 13 && checkMat[j, i] > 0)
                    {

                        count1++;
                        tempSeria1.Add(new ccCard((byte)(j + 1), (eColor)i));
                        //למקרה בו יש 2 סריות זהות
                        if (checkMat[j, i] / 10 == 2)
                        {
                            count2++;
                            tempSeria2.Add(new ccCard((byte)(j + 1), (eColor)i));
                        }
                        j++;

                    }
                    //if (count1 > 3)
                    //    SplitingSerias(tempSeria1.ToList(), count1);

                    //else 
                        if (count1 > 2)
                    {
                        OptionalsSerias.Add(tempSeria1.ToList());

                    }
                    //if (count2 > 3)
                    //    SplitingSerias(tempSeria2.ToList(), count2);
                    //else 
                        if (count2 > 2)
                    {
                        OptionalsSerias.Add(tempSeria2.ToList());

                    }
                    tempSeria1.Clear();
                    tempSeria2.Clear();

                }
            }  
             
            for (int i = 0; i < 13; i++)
            {
                for (j = 0, count1 = 0, count2 = 0; j < 4; j++)
                {

                    //לכיוון ימין
                    //בדיקת כמות הקלפים לכיוון ימין -סדרת צבעים
                    if (checkMat[i, j] > 0)
                    {
                        count1++;
                        tempSeria1.Add(new ccCard((byte)(i + 1), (eColor)j));
                        //למקרה בו יש 2 סריות זהות
                        if (checkMat[i, j] / 10 == 2)
                        {
                            count2++;
                            tempSeria2.Add(new ccCard((byte)(i + 1), (eColor)j));
                        }
                    }
                }
                if (count1 > 2)
                {
                    OptionalsSerias.Add(tempSeria1.ToList());
                   
                }
                if (count2 > 2)
                {
                    OptionalsSerias.Add(tempSeria2.ToList());
                    
                }
                tempSeria1.Clear();
                tempSeria2.Clear();

                //if (joker_cnt > 0 && must_joker_cnt == 0)
                //{ 
                    
                //}
            }
            #endregion



            // אתחול הלוח הטוב ביותר בלוח המשחק הנוכחי למקרה שהמחשב לא מוצא סדרות
            BestBoard = mainBoard;
            // שליחה לפונקציה המוצאת את אפשרות הסידור הטובה ביותר
            RecFindBestOption(OptionalsSerias.ToList());
            
            // שליחת כל הקלפים בלוח הטוב יותר לבנייה מחדש כיון שבנה אותם בלי initializeComponent
            List<List<ccCard>> copyBestBoard = new List<List<ccCard>>();
            foreach (List<ccCard> lstCrd in BestBoard)
            {
                List<ccCard> tmp = new List<ccCard>();
                foreach (ccCard card in lstCrd)
                {
                    tmp.Add(new ccCard(card.Number, card.getColor));
                }
                copyBestBoard.Add(tmp);
            }
            BestBoard = copyBestBoard;
            //int[] t=new int[OptionalsSerias.Count];
            //RecFindBestOption1(1,t, OptionalsSerias.ToList());
            

            //יש להוריד את הקלפים מהליסט של השחקן-בסטטוסים וברשימה
            //endTurn(best, playersBoards[turn].listCards);
            
           
            //יש להציג את קלפי המחשב על המסך
            
            //3. זריקת האירוע - אם מישהו נרשם אליו
            if (eComputerFinished!=null)
                eComputerFinished(BestBoard.ToList());

            List<ccCard> tmpList = new List<ccCard>();
            List<ccCard> tmpList1 = new List<ccCard>();
            for (int i = 0; i < BestBoard.Count; i++)
            {
               
                // שינוי הסטטוסים 
                foreach (ccCard card in BestBoard[i])
                    if (card.Status != eStatus.mainBoard)
                        card.Status = eStatus.mainBoard;
              
            }
        
            // הסרת הקלפים מקלפי השחקן         
            bool isExist ;
            foreach (ccCard card in playersBoards[turn].listCards)
            {
                isExist = false;
                for (int i = 0; i < BestBoard.Count; i++)
                    //foreach (ccCard c in BestBoard[i])
                    if ((BestBoard[i].Any(cr => cr.Number == card.Number && cr.getColor == card.getColor)))
                        //if(tempList != null && tempList.Any(cr => cr.Number == best[i].First(crd=>crd.Number == cr.Number && crd.getColor == cr.getColor).Number
                        //                                && cr.getColor == best[i].First(crd=>crd.Number == cr.Number && crd.getColor == cr.getColor).getColor))
                        // צריך לטפל במקרה שיש קלפים זהים ברשימת הקלפים של המחשב
                        isExist = true;
                if(!isExist)
                    tmpList.Add(card);
            }
            //tmpList1 = tmpList;
                
            playersBoards[turn].listCards = tmpList.ToList();
            tmpList1.Clear();
            tmpList.Clear();



            endTurn(BestBoard.ToList(), playersBoards[turn].listCards.ToList());
            BestBoard.Clear();
            OptionalsSerias.Clear();
            //מציאת קלף מהרשימה ע"י LINQ
            //MessageBox.Show((c.Find(cr => cr.Number == seriesList[0][0].Number)).Number.ToString());
            //var crd=c.First(cr =>cr.Equals(seriesList[0][0]));//לא טוב
            //MessageBox.Show(crd.Number.ToString()+" "+crd.getColor+" "+crd.Status);
            
        }

        private void SplitingSerias(List<ccCard> listToSplit, int count)
        {
            List<ccCard> temp = new List<ccCard>();
            for (int i = 0; i <= count-3; i++)
            {
                for (int j = i+3; j <= count; j++)
                {
                    temp.Clear();
                    for (int k = i; k < j; k++)
                    {
                        temp.Add(listToSplit[k]);
                    }
                    OptionalsSerias.Add(temp.ToList());
                }
            }
        }
        
        private void RecFindBestOption1(int index, int[] arr, List<List<ccCard>> opSerias)
        {
            //for (int i = index; i < arr.Length; i++)
            //{

            //    arr[i] = i;
            //    List<List<ccCard>> list = new List<List<ccCard>> { };
            //    // (אם הפונקציה מצאה אפשרות סידור (החזירה ערך חיובי
              
            //    for (int j = 1; j < arr.Length; j++)                        
            //        if (arr[j] != 0)                   
            //            list.Add(opSerias[j]);


            //    if (FindOptionSerias(list.ToList()))
            //        RecFindBestOption1(index + 1, arr, opSerias.ToList());
            //    arr[i] = 0;
                
            //}
            //for (int i = x; i <= 4; i++)
            //{
            //    t[i] = i;
            //    string s = "";

            //    for (int j = 1; j <= 4; j++)
            //        if (t[j] != 0)
            //            s += t[j].ToString();
            //    MessageBox.Show(s);

            //    recAllOptions(i + 1, t);
            //    t[i] = 0;

            //}
        }
        //106-120

        public void RecFindBestOption(List<List<ccCard>> opSerias)
        {
            int ind;
            List<List<ccCard>> newList;         
            
            // (אם הפונקציה מצאה אפשרות סידור (החזירה ערך חיובי
            FindOptionSerias(opSerias);
               
            //עוברים ברקורסיה על כל אפשרויות הסידור כדי למצוא את הטובה ביותר
            for (ind = 0; ind < opSerias.Count; ind++)
            {
                // חוסך במהלכים מיותרים
                if (opSerias.Count > 1)
                {
                    newList = copySeriasList(opSerias);
                    newList.RemoveAt(ind);
                    RecFindBestOption(newList);
                }
            }
            GC.Collect();
        }

        private List<List<ccCard>> copySeriasList(List<List<ccCard>> opSeriasMakor)
        {
            List<List<ccCard>> newList=new List<List<ccCard>>();
            List<ccCard> tempList;
            foreach (List<ccCard> itemRow in opSeriasMakor)
            {
                tempList = new List<ccCard>();
                foreach (ccCard itemCol in itemRow)
                    tempList.Add((ccCard)itemCol.Clone());
                newList.Add(tempList);
            }
            return newList;
        }

        public bool FindOptionSerias(List<List<ccCard>> OptionalsSerias)
        {
            int tmpI, tmpJ, count = 0, cnt = 0, currentScore=0;
            List<ccCard> temp = new List<ccCard> { };
            List<List<ccCard>> arrangedBoard = new List<List<ccCard>> { };
            byte[,] chkMat = (byte[,])checkMat.Clone();

            for (int k = 0; k < OptionalsSerias.Count; k++)
            {
                count = 0;
                temp.Clear();
                
                //בדיקה האם ניתן להשתמש בסדרה
                for (int i = 0; i < OptionalsSerias[k].Count; i++)
                {
                    tmpI = OptionalsSerias[k][i].Number - 1;
                    tmpJ = (int)OptionalsSerias[k][i].getColor;
                    if (chkMat[tmpI, tmpJ] > 0)
                    {
                        temp.Add((ccCard)OptionalsSerias[k][i].Clone());
                        count++;
                    }
                }
                
                // אם הסדרה חוקית
                if (count > 2 && (Asc(temp) || sameColor(temp)))
                {
                    //עדכון במטריצה
                    for (int i = 0; i < OptionalsSerias[k].Count; i++)
                    {
                        //אתחול הגישה למיקום הכרטיס במט
                        tmpI = OptionalsSerias[k][i].Number - 1;
                        tmpJ = OptionalsSerias[k][i].getColor.GetHashCode();
                        if (chkMat[tmpI, tmpJ] / 10 == 1)
                            chkMat[tmpI, tmpJ] = 0;
                        else if (chkMat[tmpI, tmpJ] == 20)
                            chkMat[tmpI, tmpJ] = 10;
                        else //if (checkMat[tmpI, tmpJ] / 10 == 2)
                            //22: 11, 21: 10
                            chkMat[tmpI, tmpJ] -= 11;
                    }

                    //הוספה ללוח המסודר
                    arrangedBoard.Add(OptionalsSerias[k]);
                    currentScore += OptionalsSerias[k].Count;
                }            
            }

            //בדיקה האם כל הקלפים החייבים בשיבוץ שובצו
            foreach (byte num in chkMat)
                //if (num % 10 != 0)
                cnt+=num % 10;
            
            if (cnt==0)
            {
                //אם ניקןד הלוח הנוכחי הוא הגדול ביותר  
                if (currentScore > maxScore)
                {
                    BestBoard = arrangedBoard.ToList();
                    maxScore = currentScore;
                }
                //return true;
            }
            return true;
        }

     

        public byte[,] BuildMat(List<ccCard> comp_card_list)
        {
            //מטריצה בה ישובצו קלפי שחקן מחשב.
            //המט' בגודל 13- הספרות האפשריות על 4- מס' הצבעים האפשרי
            byte[,] mat = new byte[13, 4];
          
            
            foreach (ccCard card in comp_card_list)
            {
                
                //אם אין קלף זהה במט וגם אינו חייב להשתמש בו
                if (card.Number!=14 && mat[card.Number - 1, card.getColor.GetHashCode()] == 0 && card.Status == eStatus.Player)
                    mat[card.Number - 1, (int)card.getColor] = 10;
                //אם אין קלף זהה וחייב להשתמש בו
                else if(card.Number!=14 && mat[card.Number - 1, card.getColor.GetHashCode()]==0 && card.Status==eStatus.mainBoard)
                       mat[card.Number - 1, (int)card.getColor] = 11; 
                //אם יש קלף זהה שאינו חייב
                else if(card.Number!=14 && mat[card.Number - 1, card.getColor.GetHashCode()]/10==1 && mat[card.Number - 1, card.getColor.GetHashCode()]%10==0)
                {  
                    //אם הקלף לא חייב
                        if(card.Status==eStatus.Player)
                            mat[card.Number - 1,(int) card.getColor] = 20;
                        //אם הקלף חייב
                        if (card.Status == eStatus.mainBoard)
                            mat[card.Number - 1, (int)card.getColor] = 21; 
                }
                //אם יש קלף זהה חייב
                else if (card.Number != 14 && mat[card.Number - 1, card.getColor.GetHashCode()] / 10 == 1 && mat[card.Number - 1, card.getColor.GetHashCode()] % 10 == 1)
                {
                    //אם הקלף לא חייב
                    if (card.Status == eStatus.Player)
                        mat[card.Number - 1, (int)card.getColor] = 21;
                    //אם הקלף חייב
                    if (card.Status == eStatus.mainBoard)
                        mat[card.Number - 1, (int)card.getColor] = 22; 
                }
                if (card.Number == 14)
                {
                    joker_cnt++;
                    if (card.Status == eStatus.mainBoard)
                        must_joker_cnt++;
                }
                
            }
            return mat;
        }

        /// <summary> 
        /// פונקציה הבודקת חוקיות הסדרות ברשימה הנשלחת אליה
        /// </summary>
        /// <param name="checkMainBoard">רשימת רשימות של אבני משחק עליהן מתבצעת הבדיקה</param>
        public bool legal(List<List<ccCard>> checkMainBoard)
        {
            //בדיקת חוקיות הלוח הראשי
            for (int i = 0; i < checkMainBoard.Count; i++)
            {
                //ראשית- אורך הסדרה חייב להיות גדול מ/שווה ל-3
                if (checkMainBoard[i].Count >= 3)
                {
                    //שליחה לפונקציות עזר הבודקות 2 אפשרויות לסדרה חוקית
                    //רק אם חוזרת תשובה חיובית מאחת מהן- הסדרה חוקית
                    if (!Asc(checkMainBoard[i]) && !sameColor(checkMainBoard[i]))
                        return false;
                }
                else
                    return false;
               
            }           
            return true;
        }
        //private void fswNetork_Changed(object sender, FileSystemEventArgs e)
        //{
        //    //@@
        //    // להמתין מעט לאחר השינוי לפני שטוענים
        //    Thread.Sleep(5000);
        //    try
        //    {
        //        if (currentPlayerName != playersBoards[turn].name)
        //        {
        //            XDocument doc = XDocument.Load(path + playersBoards[0].name + playersBoards[1].name + ".xml");
        //            var prop = doc.Element("status");
        //            if (prop != null && (string)prop.Attribute("status") == "finished")// אם השחקן השני יצא מהמשחק
        //            {
        //                PlayerClosed = true;
        //                MessageBox.Show(".השחקן השני מעוניין לצאת מהמשחק", "רמי", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                File.Delete(path + playersBoards[0].name + playersBoards[1].name + ".xml");
        //                System.Media.SystemSounds.Beep.Play();

        //            }
        //            else
        //            {
        //                LoadUcGame(path + playersBoards[0].name + playersBoards[1].name);

        //                //עבור טעינת מיקומי הפאנלים formGame - זריקת ארוע ל 
        //                //if (eLoadChangesFinished != null)
        //                //eLoadChangesFinished(path + playersBoards[0].name + playersBoards[1].name);
        //            }
        //        }
        //        else
        //            Show_Cards();

        //        ChangeTurn();
        //        MessageBox.Show(playersBoards[turn].name + "תורך לשחק"); //TODO: !לוודא שאכן מודיע לשני השחקנים על התור הנכון
        //        play();
        //        //break;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}
        public void setCurrentName(string p)
        {
            currentPlayerName = p;
        }
        /// <summary> 
        /// פונקצייה בוליאנית הבודקת האם הסדרה שקבלה מסודרת בסדר עולה
        /// </summary>
        /// <param name="checkList">רשימת אבני משחק עליהן מתבצעת הבדיקה</param>
        public bool Asc(List<ccCard> checkList)
        {
            int clr=(int)checkList[0].getColor;
            // משתנה המאותחל בספרה הראשונה של הסדרה ומקודם בכל איטרציה
            byte num = checkList[0].Number; 
            //לולאה העוברת על הרשימה
            for (int i = 1; i < checkList.Count; i++)
            {
                //בדיקה האם צבעי כל האבנים זהים
                if ((int)checkList[i].getColor == clr)
                {
                    num++;
                    // בדיקה האם הסידרה בסדר עולה
                    if (checkList[i].Number != num && checkList[i].Number != 14)
                        return false;
                }
                // טיפול בג'וקר
                else if (checkList[i].Number != 14)
                    return false;
                else
                    //קידום משתנה העזר
                    num++;
                  
            }
            return true;
        }
        /// <summary> 
        /// פונקצייה בוליאנית הבודקת האם הסדרה שקבלה הינה סדרת צבעים
        /// </summary>
        /// <param name="checkList">רשימת אבני משחק עליהן מתבצעת הבדיקה</param>
        public bool sameColor(List<ccCard> checkList)
        {
            //  אתחול משתנה עזר במספר הראשון שאמור להיות זהה בכל הסדרה
            byte num = checkList[0].Number;
            int clr;
            // אתחול מערך בוליאני המכיל אינדיקציות האם כבר קיים צבע זה בסדרה או לא
            bool [] colors=new bool[4]{false,false,false,false};
           
            //סידרה מסוג זה לא יכולה להכיל יותר מ-4 איברים
            if (checkList.Count <= 4)
            {               
               for (int i = 1; i < checkList.Count; i++)
               {
                   // טיפול בג'וקר
                   if (num == 14)
                    {
                        num = checkList[i++].Number;
                        continue;
                    }
                   // בדיקה על המספר- אם הוא זהה
                   if (checkList[i].Number == num || checkList[i].Number == 14)
                   {
                       clr = (int)checkList[i].getColor;
                       // בדיקה האם הצבע לא קיים עדיין בסדרה
                       if (!colors[clr] && checkList[i].Number!=14)
                           colors[clr] = true;
                       else if(checkList[i].Number != 14)
                           return false;
                   }
                   else
                       return false;
               }
               return true;
            }
            return false;
        }

        private void ucGame_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            try
            {
                if (currentPlayerName != playersBoards[turn].name)
                {

                    try
                    {
                        XDocument doc = XDocument.Load(path + playersBoards[0].name + playersBoards[1].name + ".xml");
                        var prop = doc.Element("status");
                        if (prop != null && (string)prop.Attribute("status") == "finished")// אם השחקן השני יצא מהמשחק
                        {
                            timer1.Stop();
                            PlayerClosed = true;
                            MessageBox.Show("The second player wants to exit from t=gae", "Rammi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            File.Delete(path + playersBoards[0].name + playersBoards[1].name + ".xml");
                            System.Media.SystemSounds.Beep.Play();
                        }
                        //XDocument doc = XDocument.Load(path + playersBoards[0].name + playersBoards[1].name + ".xml");
                        //// אם השחקן השני יצא מהמשחק
                        //if (File.Exists(path + "exit.xml"))
                        //{
                        //    timer1.Stop();
                        //    PlayerClosed = true;
                        //    MessageBox.Show(".השחקן השני מעוניין לצאת מהמשחק", "רמי", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    File.Delete(path + "exit.xml");
                        //    System.Media.SystemSounds.Beep.Play();
                        //}
                        else
                        {
                            timer1.Stop();
                            mainBoard.Clear();
                            LoadUcGame(path + playersBoards[0].name + playersBoards[1].name);

                            //עבור טעינת מיקומי הפאנלים formGame - זריקת ארוע ל 
                            if (eLoadChangesFinished != null)
                                eLoadChangesFinished(path + playersBoards[0].name + playersBoards[1].name);

                            File.Delete(path + playersBoards[0].name + playersBoards[1].name + ".xml");
                            ChangeTurn();
                            Show_Cards(turn);
                            MessageBox.Show(playersBoards[turn].name + " it is your turn to play "); //TODO: !לוודא שאכן מודיע לשני השחקנים על התור הנכון
                            play();
                 
                        }
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    timer1.Stop();
                    ChangeTurn();
                    Show_Cards(turn);
                    MessageBox.Show(playersBoards[turn].name + "תורך לשחק "); //TODO: !לוודא שאכן מודיע לשני השחקנים על התור הנכון
                    play();
                }
                //break;
            }
        
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
    }
}
