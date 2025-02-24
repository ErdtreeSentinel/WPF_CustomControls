### WPF Custom Control: `SettingsCard`

`SettingsCard` — это настраиваемый элемент управления для WPF, который позволяет отображать заголовок, описание, иконку и дополнительный контент в едином контейнере.

---

## **Использование**

Примеры использования в XAML:

### **Пример 1: Простой заголовок, описание и кнопка**
```xml
<controls:SettingsCard
    Header="Настройки приложения"
    Description="Здесь можно изменить параметры"
    Icon="&#xE790;"
    ShowIcon="True"
    HeaderFontSize="16">
    <Button Content="Настроить" />
</controls:SettingsCard>
```

### **Пример 2: Использование сложного заголовка с вложенным UI**
```xml
<controls:SettingsCard ShowIcon="False" HeaderFontSize="18">
    <controls:SettingsCard.Header>
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="Профиль" FontWeight="Bold" />
            <TextBlock Text=" (Администратор)" Opacity="0.7" />
        </StackPanel>
    </controls:SettingsCard.Header>
    <controls:SettingsCard.Description>
        <TextBlock Text="Настройки пользователя" Foreground="Gray" />
    </controls:SettingsCard.Description>
    <TextBox Text="Введите имя" Width="150" />
</controls:SettingsCard>
```

### **Пример 3: Использование свойства IsClickEnabled**
```xml
<controls:SettingsCard
    Header="Кликни меня"
    Description="Карточка с обработкой клика"
    IsClickEnabled="True"
    Click="SettingsCard_Click" />
```

### **Пример 4: Карточка с вложенной разметкой и кастомным контентом**
```xml
<controls:SettingsCard HeaderFontSize="14" ShowIcon="True" Icon="&#xE9D2;">
    <controls:SettingsCard.Header>
        <StackPanel Orientation="Vertical">
            <TextBlock Text="Системные параметры" FontWeight="Bold" />
            <TextBlock Text="Обновление и безопасность" FontStyle="Italic" Opacity="0.8" />
        </StackPanel>
    </controls:SettingsCard.Header>
    <StackPanel>
        <CheckBox Content="Автообновление" IsChecked="True" />
        <CheckBox Content="Разрешить фоновую синхронизацию" />
    </StackPanel>
</controls:SettingsCard>
```

---

## **Свойства**

| Свойство         | Тип      | Описание                                                                   | Значение по умолчанию |
| ---------------- | -------- | -------------------------------------------------------------------------- | --------------------- |
| `Header`         | `object` | Заголовок карточки (может быть строкой или сложным элементом).             | `null`                |
| `Description`    | `object` | Описание карточки (может быть строкой или сложным элементом).              | `null`                |
| `HeaderFontSize` | `double` | Размер шрифта заголовка (и также используется для описания с уменьшением). | `14.0`                |
| `Icon`           | `string` | Код символа иконки (используется шрифт-символ, например `&#xE790;`).       | `string.Empty`            |
| `ShowIcon`       | `bool`   | Определяет, отображать ли иконку.                                          | `true`                |
| `Content`        | `object` | Любой контент, который располагается справа от текста.                     | `null`                |
| `IsClickEnabled` | `bool`   | Разрешает обработку кликов по карточке.                                    | `false`               |
| `Click`          | `Event`  | Событие, вызываемое при клике, если `IsClickEnabled` установлено в `True`. | `null`                |

---

## **Описание кода**

### **1. Наследование от ****`UserControl`**

`SettingsCard` наследуется от `UserControl`, что позволяет использовать его как кастомный компонент.

```csharp
public partial class SettingsCard : UserControl
{
    public SettingsCard()
    {
        InitializeComponent();
    }
```

### **2. Определение DependencyProperty**

Каждое публичное свойство зарегистрировано через `DependencyProperty`, что позволяет использовать биндинги в XAML.

#### **Header и Description**

```csharp
public static readonly DependencyProperty HeaderProperty =
    DependencyProperty.Register("Header", typeof(object), typeof(SettingsCard), new PropertyMetadata(null));

public object Header
{
    get => GetValue(HeaderProperty);
    set => SetValue(HeaderProperty, value);
}
```

Аналогично для `Description`.

#### **Размер шрифта**

```csharp
public static readonly DependencyProperty HeaderFontSizeProperty =
    DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(SettingsCard), new PropertyMetadata(14.0));
```

#### **Иконка и её отображение**

```csharp
public static readonly DependencyProperty IconProperty =
    DependencyProperty.Register("Icon", typeof(string), typeof(SettingsCard), new PropertyMetadata("&#xE790;"));
```

```csharp
public static readonly DependencyProperty ShowIconProperty =
    DependencyProperty.Register(nameof(ShowIcon), typeof(bool), typeof(SettingsCard), new PropertyMetadata(true));
```

#### **Дополнительный контент**

```csharp
public static new readonly DependencyProperty ContentProperty =
    DependencyProperty.Register("Content", typeof(object), typeof(SettingsCard), new PropertyMetadata(null));
```

#### **Обработчик кликов**

```csharp
public static readonly DependencyProperty IsClickEnabledProperty =
    DependencyProperty.Register(nameof(IsClickEnabled), typeof(bool), typeof(SettingsCard), new PropertyMetadata(false));

public static readonly DependencyProperty ClickProperty =
    DependencyProperty.Register("Click", typeof(RoutedEventHandler), typeof(SettingsCard), new PropertyMetadata(null));
```

### **3. Разметка XAML**

#### **Правый контент с доп. иконкой при IsClickEnabled**

```xml
<ContentPresenter
    Grid.Column="2"
    Margin="10"
    HorizontalAlignment="Right"
    VerticalAlignment="Center"
    Content="{Binding Content, ElementName=root}" />

<TextBlock
    Grid.Column="3"
    FontFamily="{StaticResource SymbolThemeFontFamily}"
    Text="&#xE76C;"
    Visibility="{Binding IsClickEnabled, ElementName=root, Converter={StaticResource BooleanToVisibilityConverter}}" />
```

---

## **Заключение**

Этот компонент полезен для настройки карточек настроек, уведомлений или других интерфейсных элементов, где требуется компактное представление заголовка, описания и действий. Он поддерживает клики, изменяемые заголовки и вложенные элементы.

