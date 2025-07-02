using System.ComponentModel.DataAnnotations;

public class RegisterDTO
{
    [Required(ErrorMessage = "Họ tên không được để trống")]
    [MaxLength(255)]
    public required string FullName { get; set; }

    [Required(ErrorMessage = "Giới tính không được để trống")]
    public bool Gender { get; set; } = true; // true: Nam, false: Nữ

    [Required(ErrorMessage = "Ngày sinh không được để trống")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [RegularExpression(@"^0(3[2-9]|5[2689]|7[06-9]|8[1-5]|9[0-9])\d{7}$",
        ErrorMessage = "Số điện thoại không hợp lệ")]
    public required string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [MaxLength(255)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "CCCD không được để trống")]
    [RegularExpression(@"^(00[1-9]|0[1-9][0-9]|09[0-6])[0-9](0[0-9]|[1-9][0-9])\d{6}$", ErrorMessage = "CCCD không hợp lệ")]
    public required string CCCD { get; set; }

    [MaxLength(255)]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,30}$",
        ErrorMessage = "Mật khẩu phải dài 6–30 ký tự và bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt")]
    public required string Password { get; set; }
}
