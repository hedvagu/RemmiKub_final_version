using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BL;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace Dal
{
    public class SaveToXml
    {
        //XDocument doc;
        public void SaveProperties(int numOfPlayers, int trn,string[] playersNames, bool[] playersKinds, List<ccCard>[] playersCards, List<ccCard> boxCard,List<List<ccCard>> mainBoard, List<Point> seriesLocations)
        {

            //FileStream fs;
            //SoapFormatter sf;

            //fs = new FileStream("SavedGame.xml", FileMode.OpenOrCreate);
            //sf = new SoapFormatter();
            //sf.Serialize(fs, playersCards);
            //fs.Close();
            XElement prop = new XElement(
                 new XElement("properties", new XAttribute("numOfPlayers", numOfPlayers), new XAttribute("turn", trn)));

            for (int i = 0; i < numOfPlayers; i++)
            {
                int j;
                XElement plyrs = new XElement("player" + (i + 1).ToString(),
                    new XAttribute("name", playersNames[i]), new XAttribute("computer", playersKinds[i]));

                for (j = 0; j < playersCards[i].Count; j++)
                {
                    plyrs.Add(new XElement("card" + (j + 1).ToString(),
                        new XAttribute("number", playersCards[i][j].Number), new XAttribute("color", playersCards[i][j].getColor)));

                }
                plyrs.Add(new XAttribute("cntCard",j));
                prop.Add(plyrs);
            }

            XElement box = new XElement("box");
            for (int i = 0; i < boxCard.Count; i++)
            {
                box.Add(new XElement("card" + (i + 1).ToString(),
                     new XAttribute("number", boxCard[i].Number), new XAttribute("color", boxCard[i].getColor), new XAttribute("status", boxCard[i].Status)));

            }
            prop.Add(box);

            XElement series = new XElement("mainBoard");
            for (int i = 0; i < mainBoard.Count; i++)
            {
                XElement seria = new XElement("seria" + (i + 1).ToString(),
                    new XAttribute("x", seriesLocations[i].X), new XAttribute("y", seriesLocations[i].Y));
                for (int j = 0; j < mainBoard[i].Count; j++)
                {
                    seria.Add(new XElement("card" + (j + 1).ToString(),
                     new XAttribute("number", mainBoard[i][j].Number), new XAttribute("color", mainBoard[i][j].getColor), new XAttribute("status", mainBoard[i][j].Status)));
                }
                series.Add(seria);
            }
            prop.Add(series);
            // prop.Save("RammyCube\\Dal\\SavedProperties.xml");
            prop.Save("SavedGame.xml");
        }

       

    }
}
