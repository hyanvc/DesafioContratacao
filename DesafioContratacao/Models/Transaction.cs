using DesafioContratacao.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Transaction
{
    [Required]
    public DateTime Date { get; set; } = DateTime.Today;

    [Required]
    [StringLength(100, ErrorMessage = "Product Name cannot be longer than 100 characters.")]
    public string ProductName { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    [Required]
    public TransactionType Type { get; set; }
}
