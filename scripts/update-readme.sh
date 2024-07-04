#!/bin/bash

# Obter as últimas 5 tags
LATEST_TAGS=$(git tag --sort=-creatordate | head -n 5)

# Iniciar o conteúdo do README.md
echo "Iniciando conteúdo do README.md..."
{
  echo "# Meu Projeto"
  echo "Este é um README gerado automaticamente."
  echo ""
  echo "## Histórico de Tags"
  echo ""
} > ./../README-UPDATES.md

# Adicionar informações sobre cada tag ao README.md
for TAG in $LATEST_TAGS; do
  echo "Iniciando conteúdo do README.md..."
  echo $TAG
  echo "### $TAG" >> ./../README-UPDATES.md
  echo "" >> ./../README-UPDATES.md
  git show $TAG --no-patch --pretty="format:%aD - %an%n%n%s%n%b" | sed '/^-----BEGIN PGP SIGNATURE-----$/,/^-----END PGP SIGNATURE-----$/d'>> ./../README-UPDATES.md
  echo "" >> ./../README-UPDATES.md
done

# Adicionar data de atualização ao README.md
{
  echo "## Atualizado em: $(date)"
} >> ./../README-UPDATES.md