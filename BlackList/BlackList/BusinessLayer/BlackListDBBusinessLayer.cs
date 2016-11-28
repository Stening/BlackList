using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackList.Models;
namespace BlackList.BusinessLayer
{
    public class BlackListDbBusinessLayer
    {
        private readonly BlackListRepository _context;

        public BlackListDbBusinessLayer(BlackListRepository DbContext)
        {
            _context = DbContext;
        }





    }
}