using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.BusinessLogic
{
    public class FileBusinessLogic
    {
        public bool CheckFileNameCorrectLength(string fileName)
        {
            return fileName.Length < 20;
        }
    }
}