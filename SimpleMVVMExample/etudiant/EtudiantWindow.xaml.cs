using System;
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
using System.Collections.ObjectModel;
using System.Diagnostics;
using ecole_management_data;

namespace SimpleMVVMExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EtudiantWindow : Window
    {

        private view_model_Etudiant _my_view_etudiant = view_model_Etudiant.get_instance_view_model_Etudiant();



        public EtudiantWindow()
        {
            InitializeComponent();



        }

        //public void changement_de_context_car_autre_windows(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    DataContext = null;
        //    DataContext = view_model_Etudiant.get_instance_view_model_Etudiant();
        //}

        private void Btn_ajout_Click(object sender, RoutedEventArgs e)
        {

                    _my_view_etudiant.Add(new etudiants
                    {
                        Nom = TextBox_Nom_Etudiant.Text.ToString(),
                        Prenom = TextBox_Prenom_Etudiant.Text.ToString()
                    });
                    TextBox_Nom_Etudiant.Clear();
                    TextBox_Prenom_Etudiant.Clear();
                    DataContext = null;
                    DataContext = _my_view_etudiant;
                    _my_view_etudiant.rafraichissement_list_de_cour_apres_modification();
                    


    

        }


        private void Btn_modif_Click(object sender, RoutedEventArgs e)
        {

                    if (_my_view_etudiant.etudiant_selectionne_main_view_etudiant.Nom != null ||
                        _my_view_etudiant.etudiant_selectionne_main_view_etudiant.Prenom != null)
                    {
                        _my_view_etudiant.Modification(new etudiants
                        {
                            Nom = TextBox_Nom_Etudiant.Text,
                            Prenom = TextBox_Prenom_Etudiant.Text,
                        });
                        TextBox_Nom_Etudiant.Clear();
                        TextBox_Prenom_Etudiant.Clear();
                        DataContext = null;
                        DataContext = _my_view_etudiant;
                        
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez pas choisi d'etudiant dans la liste pour le modifier");
                    }

        }


        private void Btn_efface_Click(object sender, RoutedEventArgs e)
        {

                    if (_my_view_etudiant.etudiant_selectionne_main_view_etudiant.Nom != null ||
                        _my_view_etudiant.etudiant_selectionne_main_view_etudiant.Prenom != null)
                    {
                        _my_view_etudiant.Remove();
                        TextBox_Nom_Etudiant.Clear();
                        TextBox_Prenom_Etudiant.Clear();
                        DataContext = null;
                        DataContext = _my_view_etudiant;
                        _my_view_etudiant.rafraichissement_list_de_cour_apres_modification();
                        
                    }
                    else
                    {
                        MessageBox.Show("vous n'avez choisi d'etudiant dans la liste pour l'enlever");
                    }



        }



        private void Btn_modif_cours_de_l_etudiant_Click(object sender, RoutedEventArgs e)
        {
            /////////////////////////utiliser pour tester la fenetre etudiant 
            if (_my_view_etudiant.etudiant_selectionne_main_view_etudiant.Nom != null ||
                _my_view_etudiant.etudiant_selectionne_main_view_etudiant.Prenom != null)
            {
                Windows_etudiant_cours Windows_etudiant_cours = new Windows_etudiant_cours(_my_view_etudiant);
                if (Windows_etudiant_cours.ShowDialog() == true)
                {                    
                    DataContext = null;                        
                    DataContext = _my_view_etudiant;
                }
                _my_view_etudiant.rafraichissement_list_de_cour_apres_modification();
            }
            else
            {
                MessageBox.Show("vous n'avez pas choisi d'etudiant, pas de cours à modifier");
            }

        }

    }
}
