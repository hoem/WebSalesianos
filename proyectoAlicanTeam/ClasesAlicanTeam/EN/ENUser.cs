using ClasesAlicanTeam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.EN
{
    public class ENUser
    {
        private String account;
        private String password;
        private CADUser cad;

        public String Account
        {
            get { return account; }
            set { account = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public ENUser()
        {
            cad = new CADUser();
        }

        public ENUser(String account, String password)
        {
                this.init (account, password);
                cad = new CADUser();
        }


        public ENUser(ENUser user)
        {
                this.init (user.Account, user.Password);
                cad = new CADUser();
        }

        private void init (String account, String password)
        {
                this.account = account;
                this.password = password;
        }

        public Boolean loguin(String account, String password)
        {
            return cad.loguin(account, password);
        }

    }
}
