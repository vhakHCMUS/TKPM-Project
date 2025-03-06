using TKPM_Project.Models;

namespace TKPM_Project.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account GetById(int id);
        void Add(Account account);
        void Update(Account account);
        void Delete(int id);
    }
    public class MockAccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new()
        {
            new Account { Id = 1, Username = "admin", PasswordHash = "hashedpass", Role = "Admin" },
            new PremiumAccount { Id = 2, Username = "premiumUser", PasswordHash = "premiumhash", PremiumExpiryDate = DateTime.Now.AddMonths(1) },
            new GuestAccount { Id = 3, GuestSessionExpiry = DateTime.Now.AddHours(2), Username = "Guest", PasswordHash = string.Empty }
        };

        public IEnumerable<Account> GetAll() => _accounts;

        public Account GetById(int id) => _accounts.FirstOrDefault(a => a.Id == id);

        public void Add(Account account)
        {
            account.Id = _accounts.Max(a => a.Id) + 1;
            _accounts.Add(account);
        }

        public void Update(Account account)
        {
            var existing = GetById(account.Id);
            if (existing == null) return;
            existing.Username = account.Username;
            existing.PasswordHash = account.PasswordHash;
            existing.Role = account.Role;
        }

        public void Delete(int id)
        {
            var account = GetById(id);
            if (account != null) _accounts.Remove(account);
        }
    }
}
