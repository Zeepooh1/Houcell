using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouCell.Models
{
    public class LoginState
    {
        public LoginState(int state)
        {
            this.State = state;
          
        }
        int State { get; set; }
    }
}
