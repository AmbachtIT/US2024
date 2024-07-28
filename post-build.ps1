# This script is executed in the post-build event

# Build tailwind stuff
.\tools\tailwindcss-windows-x64.exe -i ".\src\D66.US2024.App\wwwroot\css\app.css" -o ".\src\D66.US2024.App\wwwroot\css\app.min.css"