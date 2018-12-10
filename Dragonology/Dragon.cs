using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonology
{
    public class Dragon
    {

        #region FIELDS

        private string _name;
        private string _breath;
        private string _located;
        private int _age;
        private string _color;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Breath
        {
            get { return _breath; }
            set { _breath = value; }
        }

        public string Located
        {
            get { return _located; }
            set { _located = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Dragon()
        {

        }

        public Dragon(string name)
        {
            _name = name;
        }
        
        #endregion
    }
}
