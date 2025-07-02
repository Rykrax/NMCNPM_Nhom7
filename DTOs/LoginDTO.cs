using System.ComponentModel.DataAnnotations;

public class LoginDTO
{
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [RegularExpression(@"^0(3[2-9]|5[2689]|7[06-9]|8[1-5]|9[0-9])\d{7}$", 
    ErrorMessage = "Số điện thoại không hợp lệ")]
    public required string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,30}$", 
    ErrorMessage = "Mật khẩu phải dài 6–30 ký tự và bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt")]
    public required string Password { get; set; }
}
