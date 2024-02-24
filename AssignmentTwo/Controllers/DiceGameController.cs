using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AssignmentTwo.Controllers
{
    /// <summary>
    /// Controller for handling operations related to a dice game.
    /// </summary>
    public class DiceGameController : ApiController
    {
        /// <summary>
        /// Calculates the number of ways to roll a sum of 10 with two dice.
        /// </summary>
        /// <param name="m">The number of sides on the first die.</param>
        /// <param name="n">The number of sides on the second die.</param>
        /// <returns>A string indicating the total number of ways to get the sum 10.</returns>
        /// <example>
        ///     Get: http://localhost:XXX/api/j2/dicegame/6/8 => "There are 5 total ways to get the sum 10."
        /// </example>
        /// <example>
        ///    http://localhost:XXXX/api/j2/dicegame/5/5 => "There are 1 total ways to get the sum 10." 
        /// </example>
        [HttpGet]
        [Route("api/j2/dicegame/{m}/{n}")]
        public string NumberOfWaysToGetTen(int m, int n) {
            int countPossibilties = 0;
            int target = 10;

            for (int i = 1; i <= m; i++){
                for (int j = 1; j <= n; j++)
                {
                    int sum = i + j;
                    if ( sum == target)
                    {
                        countPossibilties++;
                    }
                }
            }

            return "There are " + countPossibilties + " total ways to get the sum 10.";
        }
    }
}
