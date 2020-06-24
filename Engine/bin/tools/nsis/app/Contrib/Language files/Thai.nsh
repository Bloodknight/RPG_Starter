;Language: Thai (1054)
;By SoKoOLz, TuW@nNu (asdfuae)

!insertmacro LANGFILE "Thai" "Thai"

!ifdef MUI_WELCOMEPAGE
  ${LangFileString} MUI_TEXT_WELCOME_INFO_TITLE "待拘婬虱甲兀燿蚋勉茵卉虐患刮р暫瓠蛋 $(^NameDA) "
  ${LangFileString} MUI_TEXT_WELCOME_INFO_TEXT "却乃坿却薈用虐盥叢虐�荒へ割司揶〈探坿却薈⇒ $(^NameDA).$\r$\n$\r$\n狠劬浴腔荒稻藥坿盪秩｜鼠怦号稻號全∴郵荊荐俥痴菫虐患刮, 衡荐俥紫后卉用死慣篆東箚薈菻蔵帷高澗へ割争�犹膵級友罫〈鍛婪抃ね曽塲犁傭譬友へ$\r$\n$\r$\n$_CLICK"
!endif

!ifdef MUI_UNWELCOMEPAGE
  ${LangFileString} MUI_UNTEXT_WELCOME_INFO_TITLE "待拘婬虱甲兀勉茵卉臓狹圈〈探坿却薈用虐盥叢虐⇒ $(^NameDA)"
  ${LangFileString} MUI_UNTEXT_WELCOME_INFO_TEXT "却乃坿却薈用虐盥叢虐衡薑亶咾愕篁勉茵卉臓狹圈〈探坿却薈⇒ $(^NameDA).$\r$\n$\r$\n〈竪俥痴菫〈誕÷都　卉虐患刮Ч實, 盪担誼濡瞥最菻 $(^NameDA) 篩葢顔礫虱泰$\r$\n$\r$\n$_CLICK"
!endif

!ifdef MUI_LICENSEPAGE
  ${LangFileString} MUI_TEXT_LICENSE_TITLE "∫裕‥о致萢�國編係夛"
  ${LangFileString} MUI_TEXT_LICENSE_SUBTITLE "盪担来匚掲硬國編係夛禮朴尿虱笈勍耆奸っ刮А萢昂寤へ絵亰咫卉虐患刮 $(^NameDA)."
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM "狗劼愕騨礎兀∫裕‥о致萢�國編係夛, ヾ �溝輿恥 狆怦遊啜萢篁, へ概虱�輿恥冴喉虱機擢都∧垠股赭衝萢荊荐亰咫卉虐患刮 $(^NameDA)."
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM_CHECKBOX "狗劼愕騨礎兀∫裕‥о致萢�國編係, ヾ狹徑＜后嶋友∫勍嶋勍衡  へ概虱�輿恥冴喉虱機擢都∧垠股赭衝萢荊荐亰咫卉虐患刮 $(^NameDA). $_CLICK"
  ${LangFileString} MUI_INNERTEXT_LICENSE_BOTTOM_RADIOBUTTONS "狗劼愕騨礎兀∫裕‥о致萢�國編係,  狹徑ゝ冉狹徑＝叩顔匚嶋勍衡 へ概虱�輿恥冴喉虱機擢都∧垠股赭衝萢荊荐亰咫卉虐患刮 $(^NameDA). $_CLICK"
!endif

!ifdef MUI_UNLICENSEPAGE
  ${LangFileString} MUI_UNTEXT_LICENSE_TITLE "∫裕‥о致萢�國編係夛"
  ${LangFileString} MUI_UNTEXT_LICENSE_SUBTITLE "｜愕厖菻喉虱機擢顔匚都∧垠股譟萢控坿却薈盪秩｜ $(^NameDA)."
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM "狗劼愕騨礎兀禮∫裕‥Ч實 ｜愕辧柑懈 �溝輿恥 疆个愕�級友機擢∴郵荊荐俥痴菫〈誕÷都ゝ坿却薈盪秩｜ $(^NameDA)."
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM_CHECKBOX "狗劼愕騨礎兀∫裕‥о致萢�國編係夛, ヾ狹徑＜后嶋友∫勍嶋勍衡 へ概虱�輿恥冴喉虱機擢都∧垠股赭衝萢荊荐亰咫卉虐患刮 $(^NameDA). $_CLICK"
  ${LangFileString} MUI_UNINNERTEXT_LICENSE_BOTTOM_RADIOBUTTONS "狗劼愕騨礎兀∫裕‥о致萢�國編係夛, 狹徑ゝ冉狹徑＝叩顔匚嶋勍衡 へ概虱�輿恥冴喉虱機擢都∧垠股赭衝萢荊荐亰咫卉虐患刮 $(^NameDA). $_CLICK"
!endif

!ifdef MUI_LICENSEPAGE | MUI_UNLICENSEPAGE
  ${LangFileString} MUI_INNERTEXT_LICENSE_TOP "ヾ Page Down 狆怦様菻喉虱機擢継薈冒"
!endif

!ifdef MUI_COMPONENTSPAGE
  ${LangFileString} MUI_TEXT_COMPONENTS_TITLE "狹徑（菁校弛〕"
  ${LangFileString} MUI_TEXT_COMPONENTS_SUBTITLE "狹徑（壽Х寤へ概虱А卉礫薈匚� $(^NameDA) 荊茲愕級友〈探坿却薈"
  ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_TITLE "智妥俥葉卒"
!endif

!ifdef MUI_UNCOMPONENTSPAGE
  ${LangFileString} MUI_UNTEXT_COMPONENTS_TITLE "狹徑（菁校弛〕"
  ${LangFileString} MUI_UNTEXT_COMPONENTS_SUBTITLE "狹徑（壽Х寤へ概虱А卉礫薈匚� $(^NameDA) 荊茲愕級友臓狹圈〈探坿却薈"
!endif

!ifdef MUI_COMPONENTSPAGE | MUI_UNCOMPONENTSPAGE
  !ifndef NSIS_CONFIG_COMPONENTPAGE_ALTERNATIVE
    ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_INFO "�兀狒卻譬友へ橿帽徑墓嚢暫弌雄狆怦祐拊丗登猴嫗"
  !else
    ${LangFileString} MUI_INNERTEXT_COMPONENTS_DESCRIPTION_INFO "�兀狒卻譬友へ橿帽徑墓嚢暫弌雄狆怦祐拊丗登猴嫗"
  !endif
!endif

!ifdef MUI_DIRECTORYPAGE
  ${LangFileString} MUI_TEXT_DIRECTORY_TITLE "狹徑〃寤荊莎虱А卉虐患刮"
  ${LangFileString} MUI_TEXT_DIRECTORY_SUBTITLE "狹徑＝守膳寤級友〈探坿却薈 $(^NameDA)."
!endif

!ifdef MUI_UNDIRECTORYSPAGE
  ${LangFileString} MUI_UNTEXT_DIRECTORY_TITLE "狹徑＝翠膳寤級友〈誕÷都　卉虐患刮"
  ${LangFileString} MUI_UNTEXT_DIRECTORY_SUBTITLE "狹徑＝翠膳寤へ概虱А卉臓狹圈〈探坿却薈⇒ $(^NameDA)."
!endif

!ifdef MUI_INSTFILESPAGE
  ${LangFileString} MUI_TEXT_INSTALLING_TITLE "〉菟У坿却薈"
  ${LangFileString} MUI_TEXT_INSTALLING_SUBTITLE "盪担値禮�亰寤 $(^NameDA) 〉菟Ф戞虐患刮"
  ${LangFileString} MUI_TEXT_FINISH_TITLE "〈探坿却薈猜仲�夂"
  ${LangFileString} MUI_TEXT_FINISH_SUBTITLE "〈探坿却薈猜仲�塑拊褐"
  ${LangFileString} MUI_TEXT_ABORT_TITLE "〈探坿却薈禽∥÷都"
  ${LangFileString} MUI_TEXT_ABORT_SUBTITLE "〈探坿却薈篩葯蔽腮柄細坦"
!endif

!ifdef MUI_UNINSTFILESPAGE
  ${LangFileString} MUI_UNTEXT_UNINSTALLING_TITLE "〉菟�÷都　卉虐患刮"
  ${LangFileString} MUI_UNTEXT_UNINSTALLING_SUBTITLE "盪担値禮�亰寤 $(^NameDA) 〉菟Ф戞臓狹圈〈探坿却薈."
  ${LangFileString} MUI_UNTEXT_FINISH_TITLE "〈誕÷都　卉虐患刮о蔽腮編藕"
  ${LangFileString} MUI_UNTEXT_FINISH_SUBTITLE "〈誕÷都　卉虐患刮о蔽腮編藕盍楕塑拊褐"
  ${LangFileString} MUI_UNTEXT_ABORT_TITLE "〈誕÷都　卉虐患刮Ф戞臓狹圈"
  ${LangFileString} MUI_UNTEXT_ABORT_SUBTITLE "〈誕÷都　卉虐患刮т争篇狠腮"
!endif

!ifdef MUI_FINISHPAGE
  ${LangFileString} MUI_TEXT_FINISH_INFO_TITLE "〈探坿却薈用虐盥叢虐⇒  $(^NameDA) 〉菟о蔽腮編藕"
  ${LangFileString} MUI_TEXT_FINISH_INFO_TEXT "$(^NameDA) 箚藏戞虐患刮�с項っ怦友ね曽塲犁傭譬友へ梶悼$\r$\n$\r$\nヾ 猜仲�夂項衝萢市患冉虐患刮�儺壟港儺"
  ${LangFileString} MUI_TEXT_FINISH_INFO_REBOOT "爐致萢Г輿菖楳詰柱⇒Г愕�犹膵級友稚糞卉血狆怦諭卉虐患刮Б友 $(^NameDA) �狠嫗挫虱, へ概虱А卉� 稚細 犂寞打衡蜆冒?"
!endif

!ifdef MUI_UNFINISHPAGE
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_TITLE "〈誕÷都　卉虐患刮�儺壟港儺國友 $(^NameDA) 〉菟о蔽腮柄細坦"
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_TEXT "$(^NameDA) 箚藏戞臓狹圈様；辧爐致萢Г輿菖楳詰柱⇒Г愕疆蘿 $\r$\n$\r$\nヾ 猜仲�夂 狆怦融坿帽蚋�虐患刮�儺壟港儺"
  ${LangFileString} MUI_UNTEXT_FINISH_INFO_REBOOT "爐致萢Г輿菖楳詰柱⇒Г愕�犹膵級友稚糞卉豬禮〈歎寤�罫〈誕÷都　卉虐患刮Б友 $(^NameDA) 猜仲�夂, へ概虱А卉�稚細劇鑑訛嚢實篷?"
!endif

!ifdef MUI_FINISHPAGE | MUI_UNFINISHPAGE
  ${LangFileString} MUI_TEXT_FINISH_REBOOTNOW "稚細 犂寞打衡"
  ${LangFileString} MUI_TEXT_FINISH_REBOOTLATER "�控虱А卉 稚細郡蘿袖項友 荊謀僥"
  ${LangFileString} MUI_TEXT_FINISH_RUN "&恥 $(^NameDA)"
  ${LangFileString} MUI_TEXT_FINISH_SHOWREADME "&疂冠智妥俥葉卒"
  ${LangFileString} MUI_BUTTONTEXT_FINISH "&猜仲�夂"  
!endif

!ifdef MUI_STARTMENUPAGE
  ${LangFileString} MUI_TEXT_STARTMENU_TITLE "狹徑＝翠 Start Menu"
  ${LangFileString} MUI_TEXT_STARTMENU_SUBTITLE "狹徑＝翠 Start Menu 狆怦擁忠勍�柱気儼⇒ $(^NameDA). "
  ${LangFileString} MUI_INNERTEXT_STARTMENU_TOP "狹徑＝守 Start Menu 荊茲愕級友〈竪佇忠勍�柱気儼⇒р暫瓠蛋, へ蛎僥片倉旦〉帽勘怦沃衝萢蔽蚋п翠巣冒葢顔葉ヾ蘿"
  ${LangFileString} MUI_INNERTEXT_STARTMENU_CHECKBOX "篩莎虱�忠勍 �柱気儼"
!endif

!ifdef MUI_UNCONFIRMPAGE
  ${LangFileString} MUI_UNTEXT_CONFIRM_TITLE "臓狹圈〈探坿却薈 $(^NameDA)"
  ${LangFileString} MUI_UNTEXT_CONFIRM_SUBTITLE "臓狹圈〈探坿却薈 $(^NameDA) �÷っ怦友ね曽塲犁傭譬友へ"
!endif

!ifdef MUI_ABORTWARNING
  ${LangFileString} MUI_TEXT_ABORTWARNING "へ梶壕礙肪徑蝿劼愕級友〈竪侏諭�　卉虐患刮Б友 $(^Name)?"
!endif

!ifdef MUI_UNABORTWARNING
  ${LangFileString} MUI_UNTEXT_ABORTWARNING "へ梶壕礙肪徑蝿劼愕級友〈値諭�　卉臓狹圈〈探坿却薈⇒ $(^Name)?"
!endif
