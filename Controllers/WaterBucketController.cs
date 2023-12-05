using Microsoft.AspNetCore.Mvc;
using WaterBucketChallenge.Models;
namespace WaterBucketChallenge.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class WaterBucketController(IWaterBucketService waterBucketService) : ControllerBase
{
    private readonly IWaterBucketService _waterBucketService = waterBucketService;

    [HttpGet("ShowSteps/{x}/{y}/{z}")]
    public string ShowSteps(int x, int y, int z)
    {
        return _waterBucketService.ShowSteps(x, y, z);
    }
}