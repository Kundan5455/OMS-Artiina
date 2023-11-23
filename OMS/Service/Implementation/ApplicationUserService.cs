using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OMS.Model;
using OMS.Repository;

namespace OMS.Service.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<ApplicationUser> Add(ApplicationUser user)
        {
            return await _applicationUserRepository.Add(user);
        }

        public async Task<IEnumerable<ApplicationUser>> ReadFromLocal()
        {
            FileStream fileStream = new FileStream("F:\\Atriina\\.NET Assignment\\OMS\\OMS\\OMS_UserData.xlsx", FileMode.Open, FileAccess.Read);
            IWorkbook workbook = new XSSFWorkbook(fileStream);
            ISheet sheet = workbook.GetSheetAt(0);

            List<ApplicationUser> users = new List<ApplicationUser>();

            for (int row = 2; row <= sheet.LastRowNum; row++)
            {
                IRow excelRow = sheet.GetRow(row);

                ApplicationUser user = new ApplicationUser
                {
                    Id = (int)excelRow.GetCell(0).NumericCellValue,
                    UserName = excelRow.GetCell(1).StringCellValue,
                    Name = excelRow.GetCell(2).StringCellValue,
                    Password = excelRow.GetCell(3).StringCellValue,
                    Email = excelRow.GetCell(4).StringCellValue,
                    AccessLevel = (int)excelRow.GetCell(5).NumericCellValue,
                    SendEmail = excelRow.GetCell(6).BooleanCellValue
                };

                users.Add(user);
            }

            return await _applicationUserRepository.BulkInsert(users);
        }

        public async Task Delete(int id)
        {
            await _applicationUserRepository.Delete(id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await _applicationUserRepository.GetAll();
        }

        public async Task<ApplicationUser> Update(ApplicationUser user)
        {
            return await _applicationUserRepository.Update(user);
        }
    }
}
