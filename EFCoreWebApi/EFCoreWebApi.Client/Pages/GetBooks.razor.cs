
using EFCoreWebApi.Client.Models;
using System.Net.Http.Json;

namespace EFCoreWebApi.Client.Pages;
public partial class GetBooks
{
    private readonly HttpClient client = new();
    private string _baseUrl = "https://localhost:7264/api/Books";
    private List<BookDto> BookList = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadBooks();
    }

    private async Task LoadBooks()
    {
        var response = await GetBooksList();
        if (response?.Result != null)
        {
            BookList = response.Result;
            await InvokeAsync(StateHasChanged); // Ensure UI updates
        }
    }

    public async Task<Response<List<BookDto>>> GetBooksList()
    {
        try
        {
            var response = await client.GetFromJsonAsync<Response<List<BookDto>>>(_baseUrl);
            return response ?? new Response<List<BookDto>> { IsSuccess = false, Message = "No data received" };
        }
        catch (Exception ex)
        {
            return new Response<List<BookDto>> { IsSuccess = false, Message = ex.Message };
        }
    }

}
