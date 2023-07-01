using System;
using System.Text.RegularExpressions;


namespace PTTKHTTT_QuanLyKhachSan
{
	class InputValidation
	{
		public static bool ValidEmail(string email)
		{
			// ShowMessage: Email không hợp lệ
			const string regex = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
			bool isMatch = Regex.IsMatch(email, regex);
			if (isMatch) { return true; }
			else { return false; }
		}
		public static bool ValidPhoneNumber(string phone_number)
		{
			// ShowMessage: Số điện thoại không hợp lệ
			//const string regex = @"^0[34679][0-9]{8}$";
			const string regex = @"^0[123456789][0-9]{8}$";
			bool isMatch = Regex.IsMatch(phone_number, regex);
			if (isMatch) { return true; }
			else { return false; }
		}
		public static bool ValidDate(string date)
		{
			// ShowMessage: Ngày sinh không hợp lệ
			//const string regex = @"^(?:(0[1-9]|1[0-2])[-]([0-2][1-9]|3[0-1])|(0[1-9]|1[0-2])[-](0[1-9]|1[0-9]|2[0-9])|(0[1-9]|1[0-2])[-](00[1-9]|0[1-9]|1[0-9]|2[0-9]))[-](19|20)\d\d$";
			const string regex = @"^(?:(0[1-9]|[1-2][0-9]|3[0-1])[/](0[1-9]|1[0-2])[/](19|20)\d\d)$";
			bool isMatch = Regex.IsMatch(date, regex);
			if (isMatch) { return true; }
			else { return false; }
		}
		public static bool ValidUsername(string username)
		{
			// ShowMessage: Tên đăng nhập không hợp lệ. Tên đăng nhập phải có từ 3 đến 15 ký tự, không chứa ký tự đặc biệt
			const string regex = @"^[a-zA-Z0-9._-]{3,15}$";
			bool isMatch = Regex.IsMatch(username, regex);
			if (isMatch) { return true; }
			else { return false; }
		}
		public static bool ValidPassword(string password)
		{
			// Mật khẩu tối thiểu 8 ký tự, tối đa 15 ký tự, có ít nhất 1 ký tự viết hoa, 1 ký tự viết thường, 1 ký tự số, 1 ký tự đặc biệt
			// const string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
			// ShowMessage: Mật khẩu không hợp lệ. Mật khẩu phải có từ 5 đến 255 ký tự, không chứa khoảng trắng
			const string regex = @"^[a-zA-Z0-9!@#$%^&*]{1,50}$";
			bool isMatch = Regex.IsMatch(password, regex);
			if (isMatch) { return true; }
			else { return false; }
		}
        public static bool ValidName(string name)
        {
            // Kiểm tra không có ký tự đặc biệt
            const string specialCharacters = @"[@!#$%^&*()<>?/\|}{~:]";
            bool hasSpecialCharacter = Regex.IsMatch(name, specialCharacters);
            if (hasSpecialCharacter)
            {
                return false;
            }

            // Chuẩn hóa tên theo dạng "Lê Minh Tiến" (giữa các từ chỉ có 1 khoảng trắng)
            string[] nameParts = name.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string normalizedName = string.Join(" ", nameParts);

            // Kiểm tra tên đã chuẩn hóa
            const string nameRegex = @"^[a-zA-Z\s]+$";
            bool isMatch = Regex.IsMatch(normalizedName, nameRegex);
            return isMatch;
        }
        public static bool ValidCheckLuong_PhuCap(string input)
        {
            const string regex = @"^[1-9][0-9]*(\.[0-9]+)?$";
            bool isMatch = Regex.IsMatch(input, regex);
            if (isMatch) { return true; }
            else { return false; }
        }


    }
}
