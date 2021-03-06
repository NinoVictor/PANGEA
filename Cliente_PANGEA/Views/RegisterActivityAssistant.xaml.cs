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
using Cliente_PANGEA.Controllers;
using DataAccess;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para RegisterActivityAssistant.xaml
    /// </summary>
    public partial class RegisterActivityAssistant : Page
    {
        int idEvent = SingletonEvent.GetEvent().Id;
        Asistentes asistente;
        private List<Horarios> scheduleList = new List<Horarios>();
        private List<Actividades> activityList = new List<Actividades>();

        public RegisterActivityAssistant()
        {
            InitializeComponent();
            btn_RegisterActivityAssistantForValidate.Visibility = Visibility.Hidden;
            btn_regresarValidarAsistencia.Visibility = Visibility.Hidden;
            LoadAssistant();
            LoadActivities();
            
        }
        public RegisterActivityAssistant(Asistentes asistentes)
        {
            InitializeComponent();
            this.asistente = asistentes;
            btn_regresar.Visibility = Visibility.Hidden;
            btn_RegisterActivityAssistant.Visibility = Visibility.Hidden;
            LoadActivities();
            LoadAssistantForValidate(asistentes.Id);
        }
       
        private void LoadAssistant()
        {
            if (AsistenteController.GetLastAssistant(idEvent) != null)
            {
                list_Asistente.ItemsSource = AsistenteController.GetLastAssistant(idEvent);
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }

        }
        private void LoadAssistantForValidate(int idAssistant)
        {
            list_Asistente.ItemsSource = AsistenteController.GetAssistantsById(idAssistant);
        }
        private List<Actividades> GetAcitivities()
        {
            if (ActivityController.GetEventActivitiesSpaceAvaible(idEvent) != null)
            {
                activityList = ActivityController.GetEventActivitiesSpaceAvaible(idEvent);
                return activityList;
            }
            return null;
        }
        private void LoadActivities()
        {
            if (GetAcitivities() != null)
            {
                listView_Activities.ItemsSource = activityList;

            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }
        }
        private bool ValidateSelectedAssistant()
        {
            if (list_Asistente.SelectedItems.Count > 0)
            {
                return true;
            }
            MessageBox.Show("Por favor selecciona al Asistente");
            return false;
        }
        private bool ValidateSelectedActivity()
        {
            if (listView_Activities.SelectedItems.Count > 0 && listView_Activities.SelectedItems.Count < 2)
            {
                return true;
            }
            MessageBox.Show("Favor de seleccionar una Actividad");
            return false;
        }
        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AssistantRegister());
        }
        private bool ValidateNOTRegisterAssistantInActivity(int idActivity, int idAssistant)
        {
            if (ActivityController.ValidateNotRegisterActivityAssistant(idActivity, idAssistant) > 0)
            {
                MessageBox.Show("El asistente seleccionado ya se encuentra registrado en la actividad seleccionada");
                return true;
            }
            return false;
        }
        private void btn_RegsiterActivityAssistant_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSelectedAssistant() && ValidateSelectedActivity())
            {
                Asistentes assistant = (Asistentes)list_Asistente.SelectedItem;
                Actividades activity = (Actividades)listView_Activities.SelectedItem;
                MessageBoxResult messageBoxResult = MessageBox.Show("¿Está seguro de de registrar al asistente a la actividad?", "Confirmación de registro", MessageBoxButton.OKCancel);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    if (!ValidateNOTRegisterAssistantInActivity(activity.Id, assistant.Id))
                    {
                        if (ActivityController.RegisterActivityAssistant(assistant.Id, activity.Id) > 0)
                        {
                            MessageBox.Show("Asistente registrado con éxito");
                            if (ContinueRegistering())
                            {
                                LoadActivities();
                            }
                            else
                            {
                                NavigationService.Navigate(new AssistantRegister());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error de conexión con la base de datos");
                        }
                    }

                }
            }
        }
        private bool ContinueRegistering()
        {
            MessageBoxResult messageBoxResult1 = MessageBox.Show("¿Desea agregar alguna otra actividad?", "", MessageBoxButton.OKCancel);
            if (messageBoxResult1 == MessageBoxResult.OK)
            {
                return true;
            }
            return false;
        }

        private void btn_RegisterActivityAssistantForValidate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSelectedAssistant() && ValidateSelectedActivity())
            {
                Asistentes assistant = (Asistentes)list_Asistente.SelectedItem;
                Actividades activity = (Actividades)listView_Activities.SelectedItem;
                MessageBoxResult messageBoxResult = MessageBox.Show("¿Está seguro de de registrar al asistente a la actividad?", "Confirmación de registro", MessageBoxButton.OKCancel);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    if (!ValidateNOTRegisterAssistantInActivity(activity.Id, assistant.Id))
                    {
                        if (ActivityController.RegisterActivityAssistant(assistant.Id, activity.Id) > 0)
                        {
                            MessageBox.Show("Asistente registrado con éxito");
                            if (ContinueRegistering())
                            {
                                LoadActivities();
                            }
                            else
                            {
                                AsistentesEvento asistentesEvento = GetAssistantEvent();
                                NavigationService.Navigate(new ValidateAssistance(asistentesEvento));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error de conexión con la base de datos");
                        }
                    }

                }
            }
        }

        private void btn_regresarValidarAsistencia_Click(object sender, RoutedEventArgs e)
        {
            AsistentesEvento asistentesEvento = GetAssistantEvent();
            this.NavigationService.Navigate(new ValidateAssistance(asistentesEvento));
        }
        private AsistentesEvento GetAssistantEvent()
        {
            if (AsistentesEventoController.GetEventAssistantByIdAssistant(this.asistente.Id)!=null)
            {
                return AsistentesEventoController.GetEventAssistantByIdAssistant(this.asistente.Id);
            }
            MessageBox.Show("Error al recuperar al asistente de evento");
            return null;
        }
        private List<Horarios> GetSchedules(Actividades activity)
        {
            if (ScheduleController.GetSchedules(activity.Id)!=null)
            {
                scheduleList = ScheduleController.GetSchedules(activity.Id);
                return scheduleList;
            }
            return null;
        }

        private void listView_Activities_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listView_Activities.SelectedItems.Count > 0)
            {
                Actividades activity = (Actividades)listView_Activities.SelectedItem;
                listView_ActivitiesSchedules.ItemsSource = GetSchedules(activity);
            }
        }
    }
}
