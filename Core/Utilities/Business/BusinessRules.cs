using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            //logic === rule

         
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;



            //List<IResult> errorResults = new List<IResults>
            //foreach (var logic in logics)
            //{
            //    if (!logic.Success)
            //    {
            //        errorResults.add(logic);
            //    }  
            //}
            //return errorResults;

        }


    }
}
