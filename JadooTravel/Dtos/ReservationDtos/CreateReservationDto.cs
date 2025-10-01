namespace JadooTravel.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string TurCityCountry { get; set; }
        public string InOrderToYourRequests { get; set; }
    }
}
