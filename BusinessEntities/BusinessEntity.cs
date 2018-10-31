using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            State = States.New;
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set {_ID = value ;}
        }

        private States _State;
        public States State
        {
            get { return _State; }
            set { _State = value; }
        }

        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
    }
}
