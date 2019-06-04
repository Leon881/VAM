using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplector.Classes
{
    class Information
    {
        public string box1;
        public string box2;
        public string box3;
        public string sex;
        public string GetInfo()
        {
            if (box1 == "Обувь" && sex == "man")
                return "ManShoes";
            else if (box1 == "Обувь" && sex == "woman")
                return "WomanShoes";
            else if (box1 == "Обувь" && sex == "child")
                return "ChildShoes";
            else if (box1 == "Брюки и джинсы" && sex == "man" && box2 != "Международный размер" && box3 != "Международный размер")
                return "ManPants";
            else if (box1 == "Брюки и джинсы" && sex == "man" && box2 != "Международный размер" && box3 == "Международный размер")
                return "ManPants1";
            else if (box1 == "Брюки и джинсы" && sex == "man" && box3 != "Международный размер" && box2 == "Международный размер")
                return "ManPants2";
            else if ((box1 == "Брюки и джинсы" || box1 == "Юбки") && sex == "woman" && box2 != "Международный размер" && box3 != "Международный размер")
                return "WomanPants";
            else if ((box1 == "Брюки и джинсы" || box1 == "Юбки") && sex == "woman" && box2 != "Международный размер" && box3 == "Международный размер")
                return "WomanPants1";
            else if ((box1 == "Брюки и джинсы" || box1 == "Юбки") && sex == "woman" && box3 != "Международный размер" && box2 == "Международный размер")
                return "WomanPants2";
            else if (box1 == "Футболки" && sex == "man" && box2 != "Международный размер" && box3 != "Международный размер")
                return "ManTShirt";
            else if (box1 == "Футболки" && sex == "man" && box2 != "Международный размер" && box3 == "Международный размер")
                return "ManTShirt1";
            else if (box1 == "Футболки" && sex == "man" && box3 != "Международный размер" && box2 == "Международный размер")
                return "ManTShirt2";
            else if (box1 == "Футболки" && sex == "woman" && box2 != "Международный размер" && box3 != "Международный размер")
                return "WomanTShirt";
            else if (box1 == "Футболки" && sex == "woman" && box2 != "Международный размер" && box3 == "Международный размер")
                return "WomanTShirt1";
            else if (box1 == "Футболки" && sex == "woman" && box3 != "Международный размер" && box2 == "Международный размер")
                return "WomanTShirt2";
            else if (box2 == "Международный размер" && box3 == "Международный размер")
                return "Equality";
            else return null;

        }
    }
}
