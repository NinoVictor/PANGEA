﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Cliente_PANGEA.Controllers;
using DataAccess;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para AssistantRegister.xaml
    /// </summary>
    public partial class AssistantRegister : Page
    {
        int idEvent = SingletonEvent.GetEvent().Id;
        Asistentes assistant;
        public AssistantRegister()
        {
            InitializeComponent();
            btn_assignActivity.IsEnabled = false;
        }
        private Asistentes CreateAssistant()
        {
            assistant = new Asistentes
            {
                Nombre = txt_AssistantName.Text,
                Apellido = txt_fatherLastName.Text + " " +txt_motherLastName.Text,
                Correo = txt_email.Text,
            };
            return assistant;
        }
        private bool ValidateSaveAssistant(Asistentes assistant, int idEvent)
        {
            if (AsistenteController.SaveAssistant(assistant,idEvent)>0)
            {
                return true;
            }
            MessageBox.Show("Error en la conexión con la base de datos");
            return false;
        }
        private void btn_AssistantRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!EmptyFields())
            {
                if (EqualEmails())
                {
                    assistant = CreateAssistant();
                    if (!AsistenteController.ExistingAssistant(assistant))
                    {
                        if (ValidateSaveAssistant(assistant,idEvent))
                        {
                            MessageBox.Show("Asistente registrado con éxito");
                            btn_assignActivity.IsEnabled = true;
                            btn_AssistantRegister.IsEnabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El asistente "+ assistant.Nombre + " "+assistant.Apellido +" ya se encuentra registrado");
                    }
                }
            }
        }

        private void Button_AssignActovity(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new RegisterActivityAssistant());
        }
        
        private bool EmptyFields()
        {
            if (txt_AssistantName.Text == "" || txt_fatherLastName.Text=="" || txt_motherLastName.Text =="" || txt_email.Text =="" ||
                txt_emailConfirmation.Text =="" )
            {
                MessageBox.Show("Por favor ingresa información en todos los campos");
                return true; 
            }
            return false;
        }
        private bool EqualEmails()
        {
            if (txt_email.Text == txt_emailConfirmation.Text)
            {
                return true;
            }
            MessageBox.Show("Los correos electrónicos no coinciden, por favor inténtelo de nuevo");
            return false;
        }
        private void ValidateText(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox.Text == "")
            {
                return;
            }
            if (!Regex.IsMatch(textbox.Text, @"[A-Za-z0-9\s]+$"))
            {
                MessageBox.Show("Por favor ingresa información válida en los campos.");
                textbox.Clear();
            }
        }
        private void CorrectEmail(object sender, RoutedEventArgs e)
        {
            String expresion;
            String email = txt_email.Text;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("El formato del correo no es válido, porfavor vuelva a intentarlo");
            }
        }
        private void CleanFields()
        {
            txt_AssistantName.Text = "";
            txt_fatherLastName.Text = "";
            txt_motherLastName.Text = "";
            txt_email.Text = "";
            txt_emailConfirmation.Text = "";
            btn_AssistantRegister.IsEnabled = true;
        }

        private void Button_ClearFlieds(object sender, RoutedEventArgs e)
        {
            CleanFields();
        }
        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowAssistants());
        }
    }
}
