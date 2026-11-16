import re
from pathlib import Path

# ====== УКАЖИ ПАПКУ ТУТ ======
ROOT_DIR = r"G:\SteamLibrary\steamapps\common\RimWorld\Mods\Vanilla Gravship Expanded - Chapter 1 Russian"  # <-- поменяй на свою
# =============================

# Какие расширения обрабатываем
EXTS = {".xml", ".txt", ".json", ".yaml", ".yml"}

pattern = re.compile(r"космонафт", re.IGNORECASE)

def repl(m: re.Match) -> str:
    s = m.group(0)
    # если первая буква была заглавной — делаем "Космонавт", иначе "космонавт"
    return "Космонавт" if s[0].isupper() else "космонавт"

root = Path(ROOT_DIR)
if not root.exists():
    raise SystemExit(f"Папка не найдена: {root}")

total_files = 0
total_repl = 0

for p in root.rglob("*"):
    if not p.is_file() or p.suffix.lower() not in EXTS:
        continue

    # пробуем utf-8, если не вышло — cp1251
    try:
        text = p.read_text(encoding="utf-8")
        enc = "utf-8"
    except UnicodeDecodeError:
        text = p.read_text(encoding="cp1251")
        enc = "cp1251"

    new_text, n = pattern.subn(repl, text)
    if n > 0:
        p.write_text(new_text, encoding=enc)
        print(f"[OK] {p}  -> замен: {n}")
        total_repl += n

    total_files += 1

print(f"\nГотово. Проверено файлов: {total_files}, всего замен: {total_repl}")
