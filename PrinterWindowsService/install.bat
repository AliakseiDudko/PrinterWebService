set SERVICE_NAME="IBoxCorp Printer Service"
set SERVICE_DESCRIPTION="IBoxCorp Printer Service Description"
set SERVICE_DISPLAYNAME="IBoxCorp Printer Service Display Name"
set SERVICE_PATH="%~dp0PrinterWindowsService.exe"

sc stop %SERVICE_NAME%
sc delete %SERVICE_NAME%

timeout /t 5

sc create %SERVICE_NAME% displayname= %SERVICE_DISPLAYNAME% binpath= %SERVICE_PATH% start= auto
sc description %SERVICE_NAME% %SERVICE_DESCRIPTION%
sc start %SERVICE_NAME%

pause