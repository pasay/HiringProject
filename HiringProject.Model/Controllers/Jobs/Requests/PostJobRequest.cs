namespace HiringProject.Model.Controllers.Jobs.Requests
{
    public class PostJobRequest
    {
        /// <summary>
        /// Şirketin kayıt numarası
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// Pozisyon
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Açıklama
        /// </summary>
        public string Description { get; set; }

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
    }
}
