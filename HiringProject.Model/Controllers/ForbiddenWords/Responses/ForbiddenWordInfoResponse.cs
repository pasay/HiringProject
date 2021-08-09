using HiringProject.Model.Enums;
using System;

namespace HiringProject.Model.Controllers.ForbiddenWords.Responses
{
    public class ForbiddenWordInfoResponse
    {
        /// <summary>
        /// Yasaklı kelimenin kayıt numarası
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Yasaklı kelime
        /// </summary>
        public string Word { get; set; }
    }
}
