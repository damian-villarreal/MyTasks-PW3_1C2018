﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppPW3.Entidades;
using System.Web.SessionState;

namespace AppPW3.Servicios
{
    public class UsuarioServices : System.Web.UI.Page
    {
        TareasEntities bdTareas = new TareasEntities();


        public List<Usuario> ListarUsuarios()
        {
            return bdTareas.Usuario.ToList();
        }

        public Usuario ObtenerUsuario(int id)
        {
            return bdTareas.Usuario.FirstOrDefault(u => u.IdUsuario == id);
        }

        public bool VerificarLogin(Usuario usuario)
        {
            foreach (Usuario usuariosRegistrados in ListarUsuarios()) 
            {
                if (usuario.Email.Equals(usuariosRegistrados.Email) && usuario.Contrasenia.Equals(usuariosRegistrados.Contrasenia))
                {
                    Session["usuarioLogueado"] = usuariosRegistrados; //guardo la variable de sesión del usuario logueado

                    return true;
                }
            }
            return false;
        }

        public void RegistrarUsuario (Usuario usuario)
        {
            //hay que armarlo bien
            bdTareas.Usuario.Add(usuario);
            bdTareas.SaveChanges();

        }

        public void ActivarUsuario (Usuario usuario)
        {

        }
    }
}