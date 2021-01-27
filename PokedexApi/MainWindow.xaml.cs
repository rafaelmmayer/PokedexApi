using Newtonsoft.Json;
using PokeApiNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace PokedexApi
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        private Pokemon _pokemonAtivo;

        public Pokemon PokemonAtivo
        {
            get { return _pokemonAtivo; }
            set
            {
                if (_pokemonAtivo != value)
                {
                    _pokemonAtivo = value;
                    OnPropertyChanged("PokemonAtivo");
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            GetAllPokemon();
            listView.ItemsSource = Pokemons;
        }
        
        private void GetAllPokemon()
        {
            Pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(File.ReadAllText(@"Data\Pokemons.json"));
        }

        private void listView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PokemonAtivo = listView.SelectedItem as Pokemon;
        }
    }
}
