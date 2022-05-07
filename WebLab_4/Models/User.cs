using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebLab_4.Models
{
    public class User
    {
        [Required(ErrorMessage = "Введите email")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Remote(action: "CheckEmail", controller: "Mockups")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан день")]
        public string Day { get; set; }

        [Required(ErrorMessage = "Не указан месяц")]
        public string Month { get; set; }

        [Required(ErrorMessage = "Не указан год")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Не указан пол")]
        public string Gender { get; set; }

        public bool Remember { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Remote(action: "CheckResetEmail", controller: "Mockups")]
        public string ResetEmail { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [Remote(action: "CheckCode", controller: "Mockups")]
        public string Code { get; set; }
    }
}
