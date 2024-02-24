using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AssignmentTwo.Requests;

namespace AssignmentTwo.Controllers
{
    /// <summary>
    /// Controller for decoding secret instructions.
    /// </summary>
    public class SecretInstructionController : ApiController
    {
        /// <summary>
        /// Decodes secret instructions based on given rules.
        /// </summary>
        /// <param name="request">The request containing instructions to decode.</param>
        /// <returns>A list of decoded directions.</returns>
        /// <example>
        ///     POST: http://localhost:XXXX/api/j2/secret-instruction  
        ///     body: {
        ///         "instructions": [
        ///             "57234",
        ///             "00907",
        ///             "34100",
        ///             "99999"
        ///         ]
        ///     }
        ///     response: {
        ///         [
        ///            "right 234",
        ///            "right 907",
        ///            "left 100"
        ///         ]
        ///     }
        /// </example>
        /// <example>
        ///     POST: http://localhost:XXXX/api/j2/secret-instruction  
        ///     body: {
        ///         "instructions": [
        ///             "12345",
        ///             "15207",
        ///             "00100",
        ///             "99999"
        ///         ]
        ///     }
        ///     response: {
        ///         [
        ///            "left 345",
        ///            "right 207",
        ///            "right 100"
        ///         ]
        ///     }
        /// </example>
        [HttpPost]
        [Route("api/j2/secret-instruction")]
        public List<string> DecodeInstruction([FromBody] SecretInstructionRequest request)
        {
            List<string> decodedDirection = new List<string>();
            string currentDirection = "";
            string rightDirection = "right";
            string LeftDirection = "left";

            foreach (string instruction in request.instructions)
            {
                if (instruction == "99999")
                {
                    break;
                }
                int firstDigit = int.Parse(instruction.Substring(0, 1));
                int secondDigit = int.Parse(instruction.Substring(1, 1));
                int thirdDigit = int.Parse(instruction.Substring(2, 3));
                int sumOfDigits = firstDigit + secondDigit;
                
                if (sumOfDigits % 2 == 0)
                {
                    currentDirection = rightDirection;
                }
                else if (sumOfDigits == 0)
                {
          
                }
                else
                {
                    currentDirection = LeftDirection;
                }
                decodedDirection.Add(currentDirection + " " + thirdDigit);
            }
           
            return decodedDirection;
        }
    }
}
