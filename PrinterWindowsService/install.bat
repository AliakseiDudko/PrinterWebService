set SERVICE_NAME="IBoxCorp Printer Service"
set SERVICE_DESCRIPTION="IBoxCorp Printer Service Description"
set SERVICE_DISPLAYNAME="IBoxCorp Printer Service Display Name"
set SERVICE_ACCOUNT_NAME=".\Admin"
set SERVICE_ACCOUNT_PASSWORD="Admin"

sc stop %SERVICE_NAME%
sc delete %SERVICE_NAME%

timeout /t 5

sc create %SERVICE_NAME% displayname= %SERVICE_DISPLAYNAME% binpath= "%~dp0PrinterWindowsService.exe" start= auto obj= %SERVICE_ACCOUNT_NAME% password= %SERVICE_ACCOUNT_PASSWORD%
sc description %SERVICE_NAME% %SERVICE_DESCRIPTION%
sc start %SERVICE_NAME%

pause