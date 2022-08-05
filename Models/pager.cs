using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskEntityFramework.Models
{
    public class pager
    {
        public int Totalitem { get;  private set; }
        public int Currentpage { get; private set; }
        public int PageSize { get; private set; }

        public int Totalpages { get;  private set; }
        public int Startpage { get; private set; }
        public int Endpage { get; private set; }
        

       
        public pager ()
        {

        }
        public pager(int totalitems, int page, int PageSize = 10)
        {
            int Totalpages = (int)Math.Ceiling((decimal)totalitems / (decimal)PageSize);
            int Currentpages = page;

            int Startpage = Currentpage - 5;
            int Endpage = Currentpage + 4;
            if (Startpage <= 0)
            {
                Endpage = Endpage - (Startpage - 1);
                Startpage = 1;
            }
            if (Endpage > Totalpages)
            {
                Endpage = totalitems;
                if (Endpage > 10)
                {
                    Startpage = Endpage - 9;
                }
            }
        }
    }
}