using NoteTakerAPI.Data;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.Repositories;

public class UserRepository(NotesDbContext context) : Repository<User>(context), IUserRepository
{
}