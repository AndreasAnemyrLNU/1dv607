﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.View
{
    class MemberCatalog
    {
        public void outputCompactMemberCatalog(Model.MemberCatalog memberCatalog)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Title = "Medlemskatalog";
            Console.WriteLine(" || Personnummer   || Förnamn        || Efternamn      || ");
            Console.WriteLine("----------------------------------------------------------");
            foreach(Model.Member member in memberCatalog)
            {
                Console.WriteLine(" || {2,-14} || {0,-14} || {1,-14} || ", member.FirstName, member.LastName, member.PersNr);
                System.Threading.Thread.Sleep(500);
            }
        }

        public void outputVerboseMemberCatalog(Model.MemberCatalog memberCatalog)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Title = "OBS! Denna ska göras om!!!!!";
            Console.WriteLine(" || Personnummer   || Förnamn        || Efternamn      || ");
            Console.WriteLine("----------------------------------------------------------");
            foreach (Model.Member member in memberCatalog)
            {
                Console.WriteLine(" || {2,-14} || {0,-14} || {1,-14} || ", member.FirstName, member.LastName, member.PersNr);
                System.Threading.Thread.Sleep(500);
            }
        }

    }
}