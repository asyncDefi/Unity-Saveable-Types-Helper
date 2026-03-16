# Unity Saveable Types Helper

Small utility library that provides serializable DTOs and helper types for Unity projects where the built-in serializer is limited or inconvenient.

## What this library is for

- **State DTOs** for components such as `Transform` and `Rigidbody` to capture and apply state explicitly.
- **Custom data helpers** such as `CustomMatrix` and `MultiDimensionalList<T>` that store data in shapes Unity can serialize (lists, primitive fields).
- **Big integer support** via a string-backed `BigInteger` wrapper around `System.Numerics.BigInteger`.

The library deliberately **does not replace** Unity's own serialization of built-in types like `Vector3`, `Quaternion`, `Color`, or `Matrix4x4`. You can keep using those directly in your fields; the helpers are mainly for cases where Unity cannot serialize the data shape you need.

## Key types

- `STypes.Transform`
  - Serializable snapshot of position/rotation/scale.
  - Use `Transform.FromUnity(Transform unityTransform)` to capture state.
  - Use `state.ApplyTo(Transform unityTransform)` to apply saved state back.

- `STypes.Rigidbody` / `STypes.Rigidbody2D`
  - Minimal DTOs for velocity, mass, drag, and `isKinematic`.
  - Use `FromUnity(...)` and `ApplyTo(...)` to work with existing components.

- `STypes.CustomMatrix`
  - Serializable matrix with explicit `rows`, `columns` and `float[]` data.
  - Supports indexing via `matrix[row, column]` and static `Multiply`.

- `STypes.MultiDimensionalList<T>`
  - Stores a logical 2D grid as a flat `List<T>` plus `Rows` and `Columns`.
  - Index via `list[row, column]`, and use `Resize` to change dimensions.

- `STypes.BigInteger`
  - Wrapper around `System.Numerics.BigInteger` that stores a string internally so Unity can serialize it.

## Usage

1. Drop the files into a Unity project (for example under `Assets/Plugins/UnitySaveableTypes`).
2. Optionally keep the provided `.asmdef` files to compile runtime and tests as separate assemblies.
3. Use the DTO types in your save-data structures (ScriptableObjects, MonoBehaviours, or plain serializable classes) instead of trying to serialize unsupported shapes (nested lists, arbitrary matrices, etc.) directly.

## Tests

The file `Tests_AllSaveableTypes.cs` contains simple NUnit tests that can be run with the Unity Test Runner (Edit Mode) to verify basic round-trip behavior of the core helpers.

