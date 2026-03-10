using Microsoft.EntityFrameworkCore;
using EnterpriseServiceRequest.API.Data;
using EnterpriseServiceRequest.API.Domain.Entities;

namespace EnterpriseServiceRequest.API.Services;

public class CaseService
{
    private readonly AppDbContext _context;

    public CaseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Case>> GetAllCasesAsync()
    {
        return await _context.Cases.ToListAsync();
    
    }

    public async Task<Case?> GetCaseByIdAsync(Guid id)
    {
        return await _context.Cases.FindAsync(id);
    }

    public async Task<Case> CreateCaseAsync(Case newCase)
    {
        _context.Cases.Add(newCase);
        await _context.SaveChangesAsync();
        return newCase;
    }

    public async Task<bool> UpdateCaseAsync(Guid id, Case updatedCase)
    {
        var existing = await _context.Cases.FindAsync(id);

        if (existing == null)
            return false;

        existing.Title = updatedCase.Title;
        existing.Description = updatedCase.Description;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCaseAsync(Guid id)
    {
        var existing = await _context.Cases.FindAsync(id);

        if (existing == null)
            return false;

        _context.Cases.Remove(existing);
        await _context.SaveChangesAsync();

        return true;
    }
}