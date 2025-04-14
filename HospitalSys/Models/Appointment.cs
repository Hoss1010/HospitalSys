namespace HospitalSys.Models
{
    public class Appointment
    {
        public int id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }


    }
}
