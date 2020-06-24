;Language: Mongolian (1104)
;By Bayarsaikhan Enkhtaivan

!insertmacro LANGFILE "Mongolian" "Mongolian"

!ifdef MUI_WELCOMEPAGE
  ${LangFileString} MUI_TEXT_WELCOME_INFO_TITLE "$(^NameDA) Ñóóëãàöàä òàâòàé ìîðèë"
  ${LangFileString} MUI_TEXT_WELCOME_INFO_TEXT "$(^NameDA) ñóóëãàöûí èëáý÷èíã òà øóóä àøèãëàæ áîëíî.$\r$\n$\r$\n¯¿íèéã ñóóëãàõûí ºìíº áóñàä á¿õ ïðîãðàìóóäàà õààõûã çºâëºæ áàéíà. Ñèñòåìèéí ôàéëóóäûã øèíý÷èëáýë êîìïüþòåðýý äàõèí à÷ààëàõã¿é áàéõ áîëîìæòîé.$\r$\n$\r$\n$_CLICK"
!endif

!ifdef MUI_UNWELCOMEPAGE
  ${LangFileString} MUI_UNTEXT_WELCOME_INFO_TITLE "$(^NameDA) Ñóóëãàöûã óñòãàõ èëáý÷èíä òàâòàé ìîðèë"
  ${LangFileString} MUI_UNTEXT_WELCOME_INFO_TEXT "$(^NameDA) óñòãàöûí èëáý÷èíã òà øóóä àøèãëàæ áîëíî.$\r$\n$\r$\nÓñòãàõûí ºìíº $(^NameDA) íü àæèëëààã¿é ýñýõèéã øàëãà.$\r$\n$\r$\n$_CLICK"
!endif

!ifdef MUI_LICENSEPAGE
  ${LangFileString} MUI_TEXT_LICENSE_TITLE "Ëèöåíçèéí çºâøººðºë"
  ${LangFileString} MUI_TEXT_LICENSE_SUBTITLE "$(^NameDA)-ûã ñóóëãàõûíõàà ºìíº çºâøèëöëèéí ç¿éë¿¿äèéã óíøèíà óó."
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM "Õýðýâ çºâøèëöëèéí ç¿éëñèéã çºâøººð÷ áàéâàë, Çºâøººðëºº òîâ÷èéã äàðàí ¿ðãýëæë¿¿ëíý ¿¿. $(^NameDA)-ûã ñóóëãàõûí òóëä çààâàë çºâøººðºõ øààðäëàãàòàé."
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM_CHECKBOX "Õýðýâ çºâøèëöëèéí ç¿éëñèéã çºâøººð÷ áàéâàë, Çºâëºõ õàéðöãèéã äàðàí ¿ðãýëæë¿¿ëíý ¿¿. $(^NameDA)-ûã ñóóëãàõûí òóëä çààâàë çºâøººðºõ øààðäëàãàòàé. $_CLICK"
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM_RADIOBUTTONS "Õýðýâ çºâøèëöëèéí ç¿éëñèéã çºâøººð÷ áàéâàë, äîîðõîîñ ýõíèéã íü ñîíãîí ¿ðãýëæë¿¿ëíý ¿¿. $(^NameDA)-ûã ñóóëãàõûí òóëä çààâàë çºâøººðºõ øààðäëàãàòàé. $_CLICK"
!endif

!ifdef MUI_UNLICENSEPAGE
  ${LangFileString} MUI_UNTEXT_LICENSE_TITLE "Ëèöåíçèéí çºâøººðºë"
  ${LangFileString} MUI_UNTEXT_LICENSE_SUBTITLE "$(^NameDA) óñòãàõûí ºìíº çºâøèëöëèéí ç¿éëñèéã óíøèíà óó."
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM "Õýðýâ çºâøèëöëèéí ç¿éëñèéã çºâøººð÷ áàéâàë, Çºâøººðëºº òîâ÷èéã äàðàí ¿ðãýëæë¿¿ëíý ¿¿. $(^NameDA)-ûã óñòãàõûí òóëä çààâàë çºâøººðºõ øààðäëàãàòàé."
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM_CHECKBOX "Õýðýâ çºâøèëöëèéí ç¿éëñèéã çºâøººð÷ áàéâàë, Çºâëºõ õàéðöãèéã äàðàí ¿ðãýëæë¿¿ëíý ¿¿. $(^NameDA)-ûã óñòãàõûí òóëä çààâàë çºâøººðºõ øààðäëàãàòàé. $_CLICK"
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM_RADIOBUTTONS "Õýðýâ çºâøèëöëèéí ç¿éëñèéã çºâøººð÷ áàéâàë, äîîðõîîñ ýõíèéã íü ñîíãîí ¿ðãýëæë¿¿ëíý ¿¿. $(^NameDA)-ûã óñòãàõûí òóëä çààâàë çºâøººðºõ øààðäëàãàòàé. $_CLICK"
!endif

!ifdef MUI_LICENSEPAGE | MUI_UNLICENSEPAGE
  ${LangFileString} MUI_INNERTEXT_LICENSE_TOP "Page Down òîâ÷èéã äàðàí çºâøèëöëèéã äîîø ã¿éëãýíý ¿¿."
!endif

!ifdef MUI_COMPONENTSPAGE
  ${LangFileString} MUI_TEXT_COMPONENTS_TITLE "Íýãäëèéã ñîíãîõ"
  ${LangFileString} MUI_TEXT_COMPONENTS_SUBTITLE "$(^NameDA)-ûã ñóóëãàõàä øààðäàãäàõ õýñãèéã ñîíãîíî óó."
  ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_TITLE "Òàéëáàð"
!endif

!ifdef MUI_UNCOMPONENTSPAGE
  ${LangFileString} MUI_UNTEXT_COMPONENTS_TITLE "Íýãäëèéã ñîíãîõ"
  ${LangFileString} MUI_UNTEXT_COMPONENTS_SUBTITLE "$(^NameDA)-ûí óñòãàõ øààðäëàãàòàé íýãäëèéã ñîíãîõ."
!endif

!ifdef MUI_COMPONENTSPAGE | MUI_UNCOMPONENTSPAGE
  !ifndef NSIS_CONFIG_COMPONENTPAGE_ALTERNATIVE
    ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_INFO "Òà õóëãàíààðàà íýãäëèéí äýýð î÷èõîä ò¿¿íèé òàéëáàðûã õàðóóëíà."
  !else
    ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_INFO "Òà õóëãàíààðàà íýãäëèéí äýýð î÷èõîä ò¿¿íèé òàéëáàðûã õàðóóëíà."
  !endif
!endif

!ifdef MUI_DIRECTORYPAGE
  ${LangFileString} MUI_TEXT_DIRECTORY_TITLE "Ñóóëãàõ áàéðëàëûã ñîíãîõ"
  ${LangFileString} MUI_TEXT_DIRECTORY_SUBTITLE "$(^NameDA) ñóóëãàöûí ñóóëãàõ çàìûã ñîíãî."
!endif

!ifdef MUI_UNDIRECTORYSPAGE
  ${LangFileString} MUI_UNTEXT_DIRECTORY_TITLE "Óñòãàöûí áàéðëàëûã ñîíãîõ"
  ${LangFileString} MUI_UNTEXT_DIRECTORY_SUBTITLE "$(^NameDA)-ûã óñòãàõ õàâòñûã ñîíãîõ."
!endif

!ifdef MUI_INSTFILESPAGE
  ${LangFileString} MUI_TEXT_INSTALLING_TITLE "Ñóóëãàæ áàéíà"
  ${LangFileString} MUI_TEXT_INSTALLING_SUBTITLE "$(^NameDA)-ûã ñóóëãàæ äóóñòàë ò¿ð õ¿ëýýíý ¿¿."
  ${LangFileString} MUI_TEXT_FINISH_TITLE "Ñóóëãàæ äóóñëàà"
  ${LangFileString} MUI_TEXT_FINISH_SUBTITLE "Ñóóëãàö àìæèëòòàé áîëîâ."
  ${LangFileString} MUI_TEXT_ABORT_TITLE "Ñóóëãàëò òàñëàãäëàà"
  ${LangFileString} MUI_TEXT_ABORT_SUBTITLE "Ñóóëãàëò àìæèëòã¿é áîëîâ."
!endif

!ifdef MUI_UNINSTFILESPAGE
  ${LangFileString} MUI_UNTEXT_UNINSTALLING_TITLE "Óñòãàæ áàéíà"
  ${LangFileString} MUI_UNTEXT_UNINSTALLING_SUBTITLE "$(^NameDA) -ûã çàéëóóëæ äóóñòàë ò¿ð õ¿ëýýíý ¿¿."
  ${LangFileString} MUI_UNTEXT_FINISH_TITLE "Óñòãàæ äóóñëàà"
  ${LangFileString} MUI_UNTEXT_FINISH_SUBTITLE "Óñòãàëò àìæèëòòàé äóóñëàà."
  ${LangFileString} MUI_UNTEXT_ABORT_TITLE "Óñòãàö òàñëàãäëàà"
  ${LangFileString} MUI_UNTEXT_ABORT_SUBTITLE "Óñòãàëò àìæèëòã¿é áîëëîî."
!endif

!ifdef MUI_FINISHPAGE
  ${LangFileString} MUI_TEXT_FINISH_INFO_TITLE "$(^NameDA) Ñóóëãàöûí èëáý÷èí äóóñëàà"
  ${LangFileString} MUI_TEXT_FINISH_INFO_TEXT "$(^NameDA) íü òàíû êîìïüþòåðò ñóóëàà.$\r$\n$\r$\nÒºãñãºë äýýð äàðâàë õààíà."
  ${LangFileString} MUI_TEXT_FINISH_INFO_REBOOT "$(^NameDA)-ûí ñóóëãàöûí äàðààëàëä òà êîìïüþòåðýý äàõèí à÷ààëñíààð äóóñíà. Òà äàõèí à÷ààëàõûã õ¿ñýæ áàéíà óó?"
!endif

!ifdef MUI_UNFINISHPAGE
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_TITLE "$(^NameDA) Óñòãàöûí èëáý÷èí äóóñëàà"
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_TEXT "$(^NameDA) íü òàíû êîìïüþòåðýýñ çàéëóóëàãäëàà.$\r$\n$\r$\nÒºãñãºë äýýð äàðâàë õààíà."
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_REBOOT "$(^NameDA) Óñòãàöûí äàðààëàëä òà êîìïüþòåðýý äàõèí à÷ààëñíààð äóóñíà. Òà ä.à÷ààëìààð áàéíà óó?"
!endif

!ifdef MUI_FINISHPAGE | MUI_UNFINISHPAGE
  ${LangFileString} MUI_TEXT_FINISH_REBOOTNOW "Ä.À÷ààë"
  ${LangFileString} MUI_TEXT_FINISH_REBOOTLATER "Áè äàðàà ä.à÷ààëàõûã õ¿ñýæ áàéíà."
  ${LangFileString} MUI_TEXT_FINISH_RUN "$(^NameDA) àæèëëóóëàõ"
  ${LangFileString} MUI_TEXT_FINISH_SHOWREADME "&Readme õàðóóëàõ"
  ${LangFileString} MUI_BUTTONTEXT_FINISH "&Òºãñãºë"  
!endif

!ifdef MUI_STARTMENUPAGE
  ${LangFileString} MUI_TEXT_STARTMENU_TITLE "Start öýñíèé õàâòñûã ñîíãî"
  ${LangFileString} MUI_TEXT_STARTMENU_SUBTITLE "Start öýñ äýõ $(^NameDA) shortcut-ûí õàâòñûã ñîíãî."
  ${LangFileString} MUI_INNERTEXT_STARTMENU_TOP "Start öýñýíä ïðîãðàìûí shortcut ¿¿ñãýõ õàâòñûã ñîíãî. Ýñâýë òà øèíý íýðýýð ¿¿ñãýæ áîëíî."
  ${LangFileString} MUI_INNERTEXT_STARTMENU_CHECKBOX "Do not create shortcuts"
!endif

!ifdef MUI_UNCONFIRMPAGE
  ${LangFileString} MUI_UNTEXT_CONFIRM_TITLE "$(^NameDA)--ûí Óñòãàö"
  ${LangFileString} MUI_UNTEXT_CONFIRM_SUBTITLE "$(^NameDA) -ûã òàíû êîìïüþòåðýýñ çàéëóóëàõ."
!endif

!ifdef MUI_ABORTWARNING
  ${LangFileString} MUI_TEXT_ABORTWARNING "$(^Name) -ûí ñóóëãàöààñ ãàðìààð áàéíà óó?"
!endif

!ifdef MUI_UNABORTWARNING
  ${LangFileString} MUI_UNTEXT_ABORTWARNING "$(^Name) Óñòãàöààñ ãàðìààð áàéíà óó?"
!endif
