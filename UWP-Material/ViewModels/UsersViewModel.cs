using System.Collections.ObjectModel;

using UWP_Material.Helpers;
using UWP_Material.Models;
using UWP_Material.Services;

namespace UWP_Material.ViewModels
{
    public class UsersViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source =>
                SampleDataService.GetGridSampleData();
    }
}
