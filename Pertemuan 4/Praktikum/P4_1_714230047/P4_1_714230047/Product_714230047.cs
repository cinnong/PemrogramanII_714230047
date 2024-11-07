using System;

namespace P4_1_714230047
{
    public abstract class Product_714230047
    {
        private string myType;
        private string myTitle;

        public Product_714230047(string type, string title)
        {
            myType = type;
            myTitle = title;
        }

        public string MyType
        {
            get { return myType; }
            set { myType = value; }
        }

        public string MyTitle
        {
            get { return myTitle; }
            set { myTitle = value; }
        }

        public abstract void DisplayInfo();
    }
}
