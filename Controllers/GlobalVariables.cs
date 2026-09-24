using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VapeUnity.Models;
namespace VapeUnity.Controllers
{
    public static class GlobalVariables
    {
        public static string ImagePath = "Caminho da Imagem";
        public static string Img = "";
        public static string Email = "";
        public static string IdUser = "";
        public static int? IdCliente;
        public static bool Autenticado = false;

    }
}
