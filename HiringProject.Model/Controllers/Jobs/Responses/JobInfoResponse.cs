using HiringProject.Model.Enums;
using System;

namespace HiringProject.Model.Controllers.Jobs.Responses
{
    public class JobInfoResponse
    {
        /// <summary>
        /// İlanın kayıt numarası
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// İlanı yayınlayan şirketin kayıt numarası
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// Pozisyon
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// İlan açıklaması
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// İlanın yayında kalacağı son tarih
        /// </summary>
        public DateTime TimeToLive { get; set; }

        /// <summary>
        /// Yan haklar
        /// </summary>
        public string FringeBenefits { get; set; }

        /// <summary>
        /// Çalışma şekli
        /// </summary>
        public string WorkType { get; set; }

        /// <summary>
        /// Ücret
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// İlan skoru
        /// </summary>
        public int QualityScore { get; set; }

        /// <summary>
        /// İlan durumu
        /// </summary>
        public JobStatusEnum JobStatus { get; set; }
    }
}
