;Language: Belarusian (1059)
;Translated by Sitnikov Vjacheslav [ glory_man@tut.by ]

!insertmacro LANGFILE "Belarusian" "Byelorussian"

!ifdef MUI_WELCOMEPAGE
  ${LangFileString} MUI_TEXT_WELCOME_INFO_TITLE "Âàñ âiòàå ìàéñòàð ¢ñòàíî¢ê³ $(^NameDA)"
  ${LangFileString} MUI_TEXT_WELCOME_INFO_TEXT "Ãýòàÿ ïðàãðàìà ¢ñòàëþå $(^NameDA) íà Âàø êàìïóòàð.$\r$\n$\r$\nÏåðàä ïà÷àòêàì óñòàíî¢êi ïðàïàíóåì çà÷ûí³öü óñå ïðàãðàìû, ÿê³ÿ âûêîíâàþööà ¢ ñàïðà¢äíû ìîìàíò. Ãýòà äàïàìîæà ïðàãðàìå ¢ñòàíî¢ê³ àáíàâ³öü ñ³ñòýìíûÿ ôàéëû áåç ïåðàçàãðóçê³ êàìïóòàðà.$\r$\n$\r$\n$_CLICK"
!endif

!ifdef MUI_UNWELCOMEPAGE
  ${LangFileString} MUI_UNTEXT_WELCOME_INFO_TITLE "Âàñ âiòàå ìàéñòàð âûäàëåííÿ $(^NameDA)"
  ${LangFileString} MUI_UNTEXT_WELCOME_INFO_TEXT "Ãýòàÿ ïðàãðàìà âûäàë³öü $(^NameDA) ç Âàøàãà êàìïóòàðà.$\r$\n$\r$\nÏåðàä ïà÷àòêàì âûäàëåííÿ ïåðàêàíàéöåñÿ ¢ òûì, øòî ïðàãðàìà $(^NameDA) íå âûêîíâàåööà.$\r$\n$\r$\n$_CLICK"
!endif

!ifdef MUI_LICENSEPAGE
  ${LangFileString} MUI_TEXT_LICENSE_TITLE "Ëiöåíçiéíàå ïàãàäíåííå"
  ${LangFileString} MUI_TEXT_LICENSE_SUBTITLE "Êàë³ ëàñêà, ïðà÷ûòàéöå ¢ìîâû Ë³öýíç³éíàãà ïàãàäíåííÿ ïåðàä ïà÷àòêàì óñòàíî¢êi $(^NameDA)."
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM "Êàëi Âû ïðûìàåöå ¢ìîâû Ëiöåíçiéíàãà ïàãàäíåííÿ, íàö³ñí³öå êíîïêó $\"Çãîäçåí$\". Ãýòà íåàáõîäíà äëÿ ¢ñòàíî¢ê³ ïðàãðàìû."
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM_CHECKBOX "Êàëi Âû ïðûìàåöå ¢ìîâû Ëiöåíçiéíàãà ïàãàäíåííÿ, óñòàëþéöå ñöÿæîê í³æýé. Ãýòà íåàáõîäíà äëÿ ¢ñòàíî¢ê³ ïðàãðàìû. $_CLICK"
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM_RADIOBUTTONS "Êàëi Âû ïðûìàåöå ¢ìîâû Ë³öýíç³éíàãà ïàãàäíåííÿ, âûëó÷ûöå ïåðøû âàðûÿíò ç ïðàïàíîâàíûõ í³æýé. Ãýòà íåàáõîäíà äëÿ ¢ñòàíî¢ê³ ïðàãðàìû. $_CLICK"
!endif

!ifdef MUI_UNLICENSEPAGE
  ${LangFileString} MUI_UNTEXT_LICENSE_TITLE "Ë³öýíç³éíàå ïàãàäíåííå"
  ${LangFileString} MUI_UNTEXT_LICENSE_SUBTITLE "Êàë³ ëàñêà, ïðà÷ûòàéöå ¢ìîâû Ë³öýíç³éíàãà ïàãàäíåííÿ ïåðàä ïà÷àòêàì âûäàëåííÿ $(^NameDA)."
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM "Êàë³ Âû ïðûìàåöå ¢ìîâû Ë³öýíç³éíàãà ïàãàäíåííÿ, íàö³ñí³öå êíîïêó $\"Çãîäçåí$\". Ãýòà íåàáõîäíà äëÿ âûäàëåííÿ ïðàãðàìû. $_CLICK"
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM_CHECKBOX "Êàë³ Âû ïðûìàåöå ¢ìîâû Ë³öýíç³éíàãà ïàãàäíåííÿ, óñòàëþéöå ñöÿæîê í³æýé. Ãýòà íåàáõîäíà äëÿ âûäàëåííÿ ïðàãðàìû. $_CLICK"
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM_RADIOBUTTONS "Êàë³ Âû ïðûìàåöå ¢ìîâû Ë³öýíç³éíàãà ïàãàäíåííÿ, âûëó÷ûöå ïåðøû âàðûÿíò ç ïðàïàíàâàíûõ í³æýé. Ãýòà íåàáõîäíà äëÿ âûäàëåííÿ ïðàãðàìû. $_CLICK"
!endif

!ifdef MUI_LICENSEPAGE | MUI_UNLICENSEPAGE
  ${LangFileString} MUI_INNERTEXT_LICENSE_TOP "Âûêàðûñòî¢âàéöå êíîïêi $\"PageUp$\" i $\"PageDown$\" äëÿ ïåðàìÿø÷ýííÿ ïà òýêñöå."
!endif

!ifdef MUI_COMPONENTSPAGE
  ${LangFileString} MUI_TEXT_COMPONENTS_TITLE "Êàìïàíåíòû ïðàãðàìû, ÿêàÿ ¢ñòàë¸¢âàåööà"
  ${LangFileString} MUI_TEXT_COMPONENTS_SUBTITLE "Âûçíà÷öå êàìïàíåíòû $(^NameDA), ÿê³ÿ Âû æàäàåöå ¢ñòàëÿâàöü."
  ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_TITLE "Àï³ñàííå"
!endif

!ifdef MUI_UNCOMPONENTSPAGE
  ${LangFileString} MUI_UNTEXT_COMPONENTS_TITLE "Êàìïàíåíòû ïðàãðàìû"
  ${LangFileString} MUI_UNTEXT_COMPONENTS_SUBTITLE "Âûçíà÷öå êàìïàíåíòû $(^NameDA), ÿê³ÿ Âû æàäàåöå âûäàë³öü."
!endif

!ifdef MUI_COMPONENTSPAGE | MUI_UNCOMPONENTSPAGE
  !ifndef NSIS_CONFIG_COMPONENTPAGE_ALTERNATIVE
    ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_INFO "Óñòàëþéöå êóðñîð ìûøû íà íàçâó êàìïàíåíòà, êàá ïðà÷ûòàöü ÿãî àï³ñàííå."
  !else
    ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_INFO "Óñòàëþéöå êóðñîð ìûøû íà íàçâó êàìïàíåíòà, êàá ïðà÷ûòàöü ÿãî àï³ñàííå."
  !endif
!endif

!ifdef MUI_DIRECTORYPAGE
  ${LangFileString} MUI_TEXT_DIRECTORY_TITLE "Âûáàð ïàïê³ ¢ñòàíî¢ê³"
  ${LangFileString} MUI_TEXT_DIRECTORY_SUBTITLE "Âûçíà÷öå ïàïêó äëÿ ¢ñòàíî¢ê³ $(^NameDA)."
!endif

!ifdef MUI_UNDIRECTORYSPAGE
  ${LangFileString} MUI_UNTEXT_DIRECTORY_TITLE "Âûáàð ïàïê³ äëÿ âûäàëåííÿ"
  ${LangFileString} MUI_UNTEXT_DIRECTORY_SUBTITLE "Âûçíà÷öå ïàïêó, ç ÿêîé ïàòðýáíà âûäàë³öü $(^NameDA)."
!endif

!ifdef MUI_INSTFILESPAGE
  ${LangFileString} MUI_TEXT_INSTALLING_TITLE "Êàï³ðàâàííå ôàéëà¢"
  ${LangFileString} MUI_TEXT_INSTALLING_SUBTITLE "Ïà÷àêàéöå, êàë³ ëàñêà, âûêîíâàåööà êàï³ðàâàííå ôàéëà¢ $(^NameDA) íà Âàø êàìïóòàð..."
  ${LangFileString} MUI_TEXT_FINISH_TITLE "Óñòàíî¢êà çàâåðøàíà"
  ${LangFileString} MUI_TEXT_FINISH_SUBTITLE "Óñòàíî¢êà ïàñïÿõîâà çàâåðøàíà."
  ${LangFileString} MUI_TEXT_ABORT_TITLE "Óñòàíî¢êà ïåðàðâàíà"
  ${LangFileString} MUI_TEXT_ABORT_SUBTITLE "Óñòàíî¢êà íå çàâåðøàíà."
!endif

!ifdef MUI_UNINSTFILESPAGE
  ${LangFileString} MUI_UNTEXT_UNINSTALLING_TITLE "Âûäàëåííå"
  ${LangFileString} MUI_UNTEXT_UNINSTALLING_SUBTITLE "Ïà÷àêàéöå, êàë³ ëàñêà, âûêîíâàåööà âûäàëåííå ôàéëà¢ $(^NameDA) ç Âàøàãà êàìïóòàðà..."
  ${LangFileString} MUI_UNTEXT_FINISH_TITLE "Âûäàëåííå çàâåðøàíà"
  ${LangFileString} MUI_UNTEXT_FINISH_SUBTITLE "Âûäàëåííå ïðàãðàìû ïàñïÿõîâà çàâåðøàíà."
  ${LangFileString} MUI_UNTEXT_ABORT_TITLE "Âûäàëåííå ïåðàðâàíà"
  ${LangFileString} MUI_UNTEXT_ABORT_SUBTITLE "Âûäàëåííå âûêàíàíà íå ïî¢íàñöþ."
!endif

!ifdef MUI_FINISHPAGE
  ${LangFileString} MUI_TEXT_FINISH_INFO_TITLE "Çàêàí÷ýííå ìàéñòðà ¢ñòàíî¢ê³ $(^NameDA)"
  ${LangFileString} MUI_TEXT_FINISH_INFO_TEXT "Óñòàíî¢êà $(^NameDA) âûêàíàíà.$\r$\n$\r$\nÍàö³ñí³öå êíîïêó $\"Ãàòîâà$\" äëÿ âûéñöÿ ç ïðàãðàìû ¢ñòàíî¢ê³."
  ${LangFileString} MUI_TEXT_FINISH_INFO_REBOOT "Êàá çàêîí÷ûöü óñòàíî¢êó $(^NameDA), íåàáõîäíà ïåðàçàãðóç³öü êàìïóòàð. Ö³ æàäàåöå Âû çðàá³öü ãýòà çàðàç?"
!endif

!ifdef MUI_UNFINISHPAGE
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_TITLE "Çàêàí÷ýííå ðàáîòû ìàéñòàðà âûäàëåííÿ $(^NameDA)"
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_TEXT "Ïðàãðàìà $(^NameDA) âûäàëåíà ç Âàøàãà êàìïóòàðà.$\r$\n$\r$\nÍàö³ñí³öå êíîïêó $\"Ãàòîâà$\"êàá âûéñö³ ç ïðàãðàìû âûäàëåííÿ."
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_REBOOT "Êàá ñêîí÷ûöü âûäàëåííå  $(^NameDA), íåàáõîäíà ïåðàçàãðóç³öü êàìïóòàð. Ö³ æàäàåöå Âû çðàá³öü ãýòà çàðàç?"
!endif

!ifdef MUI_FINISHPAGE | MUI_UNFINISHPAGE
  ${LangFileString} MUI_TEXT_FINISH_REBOOTNOW "Òàê, ïåðàçàãðóç³öü êàìïóòàð çàðàç"
  ${LangFileString} MUI_TEXT_FINISH_REBOOTLATER "Íå, ïåðàçàãðóç³öü êàìïóòàð ïàçíåé"
  ${LangFileString} MUI_TEXT_FINISH_RUN "&Çàïóñö³öü $(^NameDA)"
  ${LangFileString} MUI_TEXT_FINISH_SHOWREADME "&Ïàêàçàöü ³íôàðìàöûþ àá ïðàãðàìå"
  ${LangFileString} MUI_BUTTONTEXT_FINISH "&Ãàòîâà"  
!endif

!ifdef MUI_STARTMENUPAGE
  ${LangFileString} MUI_TEXT_STARTMENU_TITLE "Ïàïêà ¢ ìåíþ $\"Ïóñê$\""
  ${LangFileString} MUI_TEXT_STARTMENU_SUBTITLE "Âûëó÷ûöå ïàïêó ¢ ìåíþ $\"Ïóñê$\" äëÿ ðàçìÿø÷ýííÿ ÿðëûêî¢ ïðàãðàìû."
  ${LangFileString} MUI_INNERTEXT_STARTMENU_TOP "Âûëó÷ûöå ïàïêó ¢ ìåíþ $\"Ïóñê$\", êóäû áóäóöü çìåø÷àíû ÿðëûê³ ïðàãðàìû. Âû òàêñàìà ìîæàöå àçíà÷ûöü ³íøàå ³ìÿ ïàïê³."
  ${LangFileString} MUI_INNERTEXT_STARTMENU_CHECKBOX "Íå ñòâàðàöü ÿðëûê³"
!endif

!ifdef MUI_UNCONFIRMPAGE
  ${LangFileString} MUI_UNTEXT_CONFIRM_TITLE "Âûäàëåííå $(^NameDA)"
  ${LangFileString} MUI_UNTEXT_CONFIRM_SUBTITLE "Âûäàëåííå $(^NameDA) ç Âàøàãà êàìïóòàðà."
!endif

!ifdef MUI_ABORTWARNING
  ${LangFileString} MUI_TEXT_ABORTWARNING "Âû ñàïðà¢äû æàäàåöå ñêàñàâàöü óñòàíî¢êó $(^Name)?"
!endif

!ifdef MUI_UNABORTWARNING
  ${LangFileString} MUI_UNTEXT_ABORTWARNING "Âû ñàïðà¢äû æàäàåöå ñêàñàâàöü âûäàëåííå $(^Name)?"
!endif
