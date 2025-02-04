using FplStatsSsr.Components.Models;
using FplStatsSsr.Components.Pages.Components;
using FplStatsSsr.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FplStatsSsr
{
    public class FplBase : ComponentBase
    {
        [Inject]
        private ILogger<FplBase> Logger { get; set; } = default!;

        [Inject]
        private GetFplDataService FplService { get; set; } = default!;

        protected IEnumerable<Player> TypedPlayers { get; set; } = default!;

        protected PlayerTable? _child; 

        protected override async Task OnInitializedAsync()
        {
            //Logger.LogInformation($"OnInitializedAsync RendererName {RendererInfo.Name} IsInteractive {RendererInfo.IsInteractive}");
            
            TypedPlayers = await FplService.GetPlayers();
            Logger.LogInformation($"Found {TypedPlayers.Count()} players");
        } 

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //Logger.LogInformation($"OnAfterRenderAsync {firstRender} RendererName {RendererInfo.Name} IsInteractive {RendererInfo.IsInteractive}");
            
            if (firstRender && _child!=null)
            {
                await _child.SortTableInvokeJsAsync();
            }
        } 
    }
}