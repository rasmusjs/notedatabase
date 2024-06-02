using lars_notedatabase.DAL;
using lars_notedatabase.Models;

namespace lars_notedatabase.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class NoteController : Controller
{
    private readonly INoteRepository<OrchestralSet> _orchestralSetRepository;
    private readonly INoteRepository<Country> _countryRepository;
    private readonly INoteRepository<Contributor> _contributorsRepository;
    private readonly INoteRepository<Instrument> _instrumentRepository;


    private readonly NoteDbContext _noteDbContext;

    public NoteController(INoteRepository<OrchestralSet> orchestralSetRepository,
        INoteRepository<Country> countryRepository,
        INoteRepository<Instrument> instrumentRepository,
        INoteRepository<Contributor> contributorsRepository,
        NoteDbContext noteDbContext)
    {
        _orchestralSetRepository = orchestralSetRepository;
        _countryRepository = countryRepository;
        _instrumentRepository = instrumentRepository;
        _contributorsRepository = contributorsRepository;
        _noteDbContext = noteDbContext;
    }

    // Get request for fetching all orchestral sets
    [HttpGet("GetOrchestralSets")]
    public async Task<IActionResult> GetAllOrchestralSets()
    {
        IEnumerable<OrchestralSet>? orchestralSets = await _orchestralSetRepository.GetAll();
        if (orchestralSets == null || !orchestralSets.Any())
        {
            return NotFound("No orchestral sets found");
        }

        return Ok(orchestralSets);
    }

    // Get request for fetching a orchestral set
    [HttpGet("GetOrchestralSet/{id:int}")]
    public async Task<IActionResult> GetOrchestralSet(int id)
    {
        OrchestralSet? orchestralSet = await _orchestralSetRepository.GetTById(id);
        if (orchestralSet == null)
        {
            return NotFound("No orchestral set found");
        }

        return Ok(orchestralSet);
    }

    [HttpPost("CreateOrchestralSet")]
    public async Task<IActionResult> CreateOrchestralSet(OrchestralSet orchestralSet)
    {
        Console.WriteLine("CreateOrchestralSet");
        Console.WriteLine(orchestralSet.Name);
        Console.WriteLine(orchestralSet.Description);
        orchestralSet.Instruments = [];

        if (orchestralSet.InstrumentsId != null)
        {
            foreach (int id in orchestralSet.InstrumentsId)
            {
                Instrument? instrument = await _instrumentRepository.GetTById(id);
                if (instrument != null) orchestralSet.Instruments.Add(instrument);
            }
        }

        if (orchestralSet.LinkTransfer != null)
        {
            orchestralSet.Links = [];
            foreach (string url in orchestralSet.LinkTransfer) orchestralSet.Links.Add(new Link(url));
        }

        OrchestralSet? newOrchestralSet = await _orchestralSetRepository.Create(orchestralSet);
        if (newOrchestralSet == null)
        {
            return StatusCode(500, "Internal server error while creating orchestral set please try again");
        }

        return Ok(newOrchestralSet.Id);
    }


    [HttpGet("GetCountries")]
    public async Task<IActionResult> GetCountries()
    {
        IEnumerable<Country>? countries = await _countryRepository.GetAll();
        if (countries == null || !countries.Any())
        {
            return NotFound("No countries found");
        }

        return Ok(countries);
    }


    [HttpPost("CreateInstrument")]
    public async Task<IActionResult> CreateInstrument(Instrument instrument)
    {
        Instrument? newInstrument = await _instrumentRepository.Create(instrument);
        if (newInstrument == null)
        {
            return StatusCode(500, "Internal server error while creating instrument please try again");
        }

        return Ok(newInstrument);
    }

    [HttpGet("DeleteInstrument/{id:int}")]
    public async Task<IActionResult> DeleteInstrument(int id)
    {
        bool deleted = await _instrumentRepository.Delete(id);
        if (deleted == false)
        {
            return StatusCode(500, "Internal server error while deleting of instrument please try again");
        }

        return Ok(deleted);
    }

    [HttpGet("GetInstruments")]
    public async Task<IActionResult> GetInstruments()
    {
        IEnumerable<Instrument>? items = await _instrumentRepository.GetAll();
        if (items == null || !items.Any())
        {
            return NotFound("No instruments found");
        }

        return Ok(items);
    }

    [HttpGet("GetContributors")]
    public async Task<IActionResult> GetContributors()
    {
        IEnumerable<Contributor>? items = await _contributorsRepository.GetAll();
        if (items == null || !items.Any())
        {
            return NotFound("No contributors found");
        }

        return Ok(items);
    }

    [HttpPost("CreateContributor")]
    public async Task<IActionResult> CreateContributor(Contributor item)
    {
        Contributor? newItem = await _contributorsRepository.Create(item);
        if (newItem == null)
        {
            return StatusCode(500, "Internal server error while creating instrument please try again");
        }

        return Ok(newItem);
    }

    [HttpGet("DeleteContributor/{id:int}")]
    public async Task<IActionResult> DeleteContributor(int id)
    {
        bool deleted = await _contributorsRepository.Delete(id);
        if (deleted == false)
        {
            return StatusCode(500, "Internal server error while deleting of item please try again");
        }

        return Ok(deleted);
    }
}