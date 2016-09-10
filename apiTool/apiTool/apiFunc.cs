using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiTool
{
    public class apiFunc
    {
        public string FuncName { get; set; }
        public string FuncVar { get; set; }
        public string  FuncAll { get; set; }
        public string FuncComment { get; set; }

        public apiFunc()
        {

        }

        public apiFunc(string funcname, string funcVar,string funcAll,string funcComment)
        {
            this.FuncName = funcname;
            this.FuncVar = funcVar;
            this.FuncAll = funcAll;
            this.FuncComment = funcComment;
        }
    }
}
