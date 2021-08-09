namespace HiringProject.Model.Controllers.Companies.Requests
{
    public class PutCompanyRemainPublishJobCountRequest
    {
        /// <summary>
        /// Şirketin kayıt numarası
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Yeni ilan yayınlama hakkı sayısı
        /// </summary>
        public int RemainPublishJobCount { get; set; }
    }
}
