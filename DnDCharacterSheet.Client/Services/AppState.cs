using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DnDCharacterSheet.Shared;

namespace DnDCharacterSheet.Client.Services
{
    public class AppState
    {

        private readonly List<Characther> characthers = new List<Characther>();
        public IReadOnlyList<Characther> Characthers => characthers;

        private Characther characther = new Characther() { Name = "Loading" };
        public Characther Characther => characther;


        // Lets components receive change notifications
        // Could have whatever granularity you want (more events, hierarchy...)
        public event Action OnChange;

        // Receive 'http' instance from DI
        private readonly HttpClient http;

        public AppState(HttpClient httpInstance)//, LocalStorage localStorageInstance)
        {
            http = httpInstance;
            
            Task.Run(async () => { await LoadDemoAsync(); });

            
            NotifyStateChanged();
        }

        protected async Task LoadDemoAsync()
        {
            try
            {
                var tmp = await http.GetJsonAsync<List<Characther>>("api/SampleData/GetCharacthers");
                //characthers.Add(new Characther() { Name = "LoadDemoAsync 2" });
                characthers.AddRange(tmp);
                characther = characthers.First();
                NotifyStateChanged();
            }
            catch(Exception e)
            {
                characthers.Add(new Characther() { Name = e.Message });
                characther = characthers.First();
                NotifyStateChanged();
            }
        }

        public void NewCharacther()
        {
            var cha = new Characther() {
                id = Characthers.Count,
                Name = "Bob the " + Characthers.Count,
            ImageUrl= @"Images\Felix.jpg"
            };
            characthers.Add(cha);
            characther = cha;
            NotifyStateChanged();
        }

        public void SetActiveCharacther(int id)
        {
            var cha = characthers.Where(x => x.id == id);
            if (cha.Count() > 0)
                characther = cha.First();
            else
                characther = new Characther() { Name = id + " was not in the set of chars" };

            NotifyStateChanged();
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

    }
}
