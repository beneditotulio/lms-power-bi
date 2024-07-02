using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("Members")]
    public class Member
    {
        [Key]
        [DisplayName("ID do Membro")]
        public string MemberID { get; set; }

        [DisplayName("Primeiro Nome")]
        public string FirstName { get; set; }

        [DisplayName("Outro Nome")]
        public string OtherName { get; set; }

        [DisplayName("Sobrenome")]
        public string LastName { get; set; }

        [DisplayName("Gênero")]
        public string Gender { get; set; }
        [ForeignKey("NationalityData")]
        [DisplayName("Nacionalidade")]
        public string Nationality { get; set; }

        [DisplayName("Nuit")]
        public string Nuit { get; set; }
        [DisplayName("Bi")]
        public string Bi { get; set; }

        [DisplayName("Tipo de Membro")]
        public string MemberType { get; set; }

        [DisplayName("Endereço")]
        public string Address { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; } = "REGISTERED";
        [DisplayName("UserId")]
        public string UserId { get; set; }

        [DisplayName("Número de Estudante")]
        public string StudentNumber { get; set; } // Novo campo para número de estudante

        //[NotMapped]
        //public string password { get; set; }

        [NotMapped]
        public string FullName 
        { 
            get 
            { 
                return $"{this.FirstName} {this.OtherName} {this.LastName}"; 
            }              
        } 

        public virtual GeneralData NationalityData { get; set; }
    }

}