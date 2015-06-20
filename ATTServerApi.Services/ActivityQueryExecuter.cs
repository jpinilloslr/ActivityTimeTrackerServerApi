using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using ATTServerApi.Model;
using ATTServerApi.Services.Contracts;
using Microsoft.CSharp;

namespace ATTServerApi.Services
{
    public class ActivityQueryExecuter : IActivityQueryExecuter
    {
        public CompilerResults CompilerResults { get; private set; }


        private void CreateQueryClass(string query)
        {            
            // Define the source code of the class.
            var source =
                "using System;                                                                    " +
                "using System.Linq;                                                               " +
                "using ATTServerApi.Model;                                                        " +
                "using System.Collections.Generic;                                                " +
                "using System.Text.RegularExpressions;                                            " +
                "                                                                                 " +
                "namespace ATTServerApi.Services                                                  " +
                "{                                                                                " +
                "   public class DynamicActivityQuery                                             " +
                "   {                                                                             " +
                "                                                                                 " +
                "       private bool RegExp(string value, string regexp)                          " +
                "       {                                                                         " +
                "           var result = false;                                                   " +
                "           if(!String.IsNullOrEmpty(value) && !String.IsNullOrEmpty(regexp))     " +
                "           {                                                                     " +
                "               Regex r = new Regex(regexp.Trim(), RegexOptions.IgnoreCase);      " +
                "               result = r.IsMatch(value.Trim());                                 " +
                "           }                                                                     " +
                "           return result;                                                        " +
                "       }                                                                         " +
                "                                                                                 " +
                "       public IEnumerable<Activity> Query(IQueryable<Activity> activities)       " +
                "       {                                                                         " +
                "           return activities.Where(delegate(Activity activity)                   " +
                "           {                                                                     " +
                "               return " + query + ";                                             " +
                "           });                                                                   " +
                "       }                                                                         " +
                "   }                                                                             " +
                "}                                                                                ";


            // Create the C# code provider.
            using (var cSharpCodeProvider = new CSharpCodeProvider())
            {
                // Create the parameters.
                var compilerParameters = new CompilerParameters
                {
                    GenerateInMemory = true
                };

                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
                compilerParameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Collections.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Text.RegularExpressions.dll");
                compilerParameters.ReferencedAssemblies.Add(@"D:\\Projects\\Web\\ATTServerApi\\ATTServerApi.Web\\bin\\ATTServerApi.Model.dll");

                // Compile the source code with the specified parameters.
                CompilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, source);
            }
        }

        public IEnumerable<Activity> Query(IQueryable<Activity> activities, String query)
        {
            IEnumerable<Activity> result = new List<Activity>();  
            CreateQueryClass(query);

            if (CompilerResults.Errors.Count == 0)
            {
                dynamic queryClass = CompilerResults.CompiledAssembly.CreateInstance("ATTServerApi.Services.DynamicActivityQuery");
                result = queryClass.Query(activities);
            }

            return result;
        }
    }
}
