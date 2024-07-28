# This script is executed in the post-build event

# Build tailwind stuff
.\tools\tailwindcss.exe -i ".\src\D66.US2024.App\wwwroot\css\input.css" -o ".\src\D66.US2024.App\wwwroot\css\tailwind.css"

# Update cache version
$guid = New-Guid
$code=@"
namespace D66.US2024.App;

public static class CssVersion
{
	public const string Value = "$guid";
}
"@

Set-Content -Value $code -Path .\src\D66.US2024.App\CssVersion.cs