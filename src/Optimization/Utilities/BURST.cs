/*using Appalachia.Core.Optimization.Metadata;
using Appalachia.Core.Optimization.Parameters;
using Unity.Mathematics;

namespace Appalachia.Core.Optimization.Utilities
{
    public static class BURST
    {
        public static class OPTIMIZATION
        {
            public delegate OptimizationResult LOSS_FUNCTION(ParameterSet set);
        }
        
        public static class IN_void
        {
            public delegate void OUT_void();

            public delegate half OUT_half();

            public delegate half2 OUT_half2();

            public delegate half3 OUT_half3();

            public delegate half4 OUT_half4();

            public delegate int OUT_int();

            public delegate int2 OUT_int2();

            public delegate int3 OUT_int3();

            public delegate int4 OUT_int4();

            public delegate int2x2 OUT_int2x2();

            public delegate int3x2 OUT_int3x2();

            public delegate int4x2 OUT_int4x2();

            public delegate int2x3 OUT_int2x3();

            public delegate int3x3 OUT_int3x3();

            public delegate int4x3 OUT_int4x3();

            public delegate int2x4 OUT_int2x4();

            public delegate int3x4 OUT_int3x4();

            public delegate int4x4 OUT_int4x4();

            public delegate float OUT_float();

            public delegate float2 OUT_float2();

            public delegate float3 OUT_float3();

            public delegate float4 OUT_float4();

            public delegate float2x2 OUT_float2x2();

            public delegate float3x2 OUT_float3x2();

            public delegate float4x2 OUT_float4x2();

            public delegate float2x3 OUT_float2x3();

            public delegate float3x3 OUT_float3x3();

            public delegate float4x3 OUT_float4x3();

            public delegate float2x4 OUT_float2x4();

            public delegate float3x4 OUT_float3x4();

            public delegate float4x4 OUT_float4x4();

            public delegate double OUT_double();

            public delegate double2 OUT_double2();

            public delegate double3 OUT_double3();

            public delegate double4 OUT_double4();

            public delegate double2x2 OUT_double2x2();

            public delegate double3x2 OUT_double3x2();

            public delegate double4x2 OUT_double4x2();

            public delegate double2x3 OUT_double2x3();

            public delegate double3x3 OUT_double3x3();

            public delegate double4x3 OUT_double4x3();

            public delegate double2x4 OUT_double2x4();

            public delegate double3x4 OUT_double3x4();

            public delegate double4x4 OUT_double4x4();

            public delegate bool OUT_bool();

            public delegate bool2 OUT_bool2();

            public delegate bool3 OUT_bool3();

            public delegate bool4 OUT_bool4();

            public delegate bool2x2 OUT_bool2x2();

            public delegate bool3x2 OUT_bool3x2();

            public delegate bool4x2 OUT_bool4x2();

            public delegate bool2x3 OUT_bool2x3();

            public delegate bool3x3 OUT_bool3x3();

            public delegate bool4x3 OUT_bool4x3();

            public delegate bool2x4 OUT_bool2x4();

            public delegate bool3x4 OUT_bool3x4();

            public delegate bool4x4 OUT_bool4x4();

            public delegate quaternion OUT_quaterinon();
        }

        public static class IN_float
        {
            public delegate void OUT_void(float a);

            public delegate half OUT_half(float a);

            public delegate half2 OUT_half2(float a);

            public delegate half3 OUT_half3(float a);

            public delegate half4 OUT_half4(float a);

            public delegate int OUT_int(float a);

            public delegate int2 OUT_int2(float a);

            public delegate int3 OUT_int3(float a);

            public delegate int4 OUT_int4(float a);

            public delegate int2x2 OUT_int2x2(float a);

            public delegate int3x2 OUT_int3x2(float a);

            public delegate int4x2 OUT_int4x2(float a);

            public delegate int2x3 OUT_int2x3(float a);

            public delegate int3x3 OUT_int3x3(float a);

            public delegate int4x3 OUT_int4x3(float a);

            public delegate int2x4 OUT_int2x4(float a);

            public delegate int3x4 OUT_int3x4(float a);

            public delegate int4x4 OUT_int4x4(float a);

            public delegate float OUT_float(float a);

            public delegate float2 OUT_float2(float a);

            public delegate float3 OUT_float3(float a);

            public delegate float4 OUT_float4(float a);

            public delegate float2x2 OUT_float2x2(float a);

            public delegate float3x2 OUT_float3x2(float a);

            public delegate float4x2 OUT_float4x2(float a);

            public delegate float2x3 OUT_float2x3(float a);

            public delegate float3x3 OUT_float3x3(float a);

            public delegate float4x3 OUT_float4x3(float a);

            public delegate float2x4 OUT_float2x4(float a);

            public delegate float3x4 OUT_float3x4(float a);

            public delegate float4x4 OUT_float4x4(float a);

            public delegate double OUT_double(float a);

            public delegate double2 OUT_double2(float a);

            public delegate double3 OUT_double3(float a);

            public delegate double4 OUT_double4(float a);

            public delegate double2x2 OUT_double2x2(float a);

            public delegate double3x2 OUT_double3x2(float a);

            public delegate double4x2 OUT_double4x2(float a);

            public delegate double2x3 OUT_double2x3(float a);

            public delegate double3x3 OUT_double3x3(float a);

            public delegate double4x3 OUT_double4x3(float a);

            public delegate double2x4 OUT_double2x4(float a);

            public delegate double3x4 OUT_double3x4(float a);

            public delegate double4x4 OUT_double4x4(float a);

            public delegate bool OUT_bool(float a);

            public delegate bool2 OUT_bool2(float a);

            public delegate bool3 OUT_bool3(float a);

            public delegate bool4 OUT_bool4(float a);

            public delegate bool2x2 OUT_bool2x2(float a);

            public delegate bool3x2 OUT_bool3x2(float a);

            public delegate bool4x2 OUT_bool4x2(float a);

            public delegate bool2x3 OUT_bool2x3(float a);

            public delegate bool3x3 OUT_bool3x3(float a);

            public delegate bool4x3 OUT_bool4x3(float a);

            public delegate bool2x4 OUT_bool2x4(float a);

            public delegate bool3x4 OUT_bool3x4(float a);

            public delegate bool4x4 OUT_bool4x4(float a);

            public delegate quaternion OUT_quaterinon(float a);
        }

        public static class IN_float_float
        {
            public delegate void OUT_void(float a, float b);

            public delegate half OUT_half(float a, float b);

            public delegate half2 OUT_half2(float a, float b);

            public delegate half3 OUT_half3(float a, float b);

            public delegate half4 OUT_half4(float a, float b);

            public delegate int OUT_int(float a, float b);

            public delegate int2 OUT_int2(float a, float b);

            public delegate int3 OUT_int3(float a, float b);

            public delegate int4 OUT_int4(float a, float b);

            public delegate int2x2 OUT_int2x2(float a, float b);

            public delegate int3x2 OUT_int3x2(float a, float b);

            public delegate int4x2 OUT_int4x2(float a, float b);

            public delegate int2x3 OUT_int2x3(float a, float b);

            public delegate int3x3 OUT_int3x3(float a, float b);

            public delegate int4x3 OUT_int4x3(float a, float b);

            public delegate int2x4 OUT_int2x4(float a, float b);

            public delegate int3x4 OUT_int3x4(float a, float b);

            public delegate int4x4 OUT_int4x4(float a, float b);

            public delegate float OUT_float(float a, float b);

            public delegate float2 OUT_float2(float a, float b);

            public delegate float3 OUT_float3(float a, float b);

            public delegate float4 OUT_float4(float a, float b);

            public delegate float2x2 OUT_float2x2(float a, float b);

            public delegate float3x2 OUT_float3x2(float a, float b);

            public delegate float4x2 OUT_float4x2(float a, float b);

            public delegate float2x3 OUT_float2x3(float a, float b);

            public delegate float3x3 OUT_float3x3(float a, float b);

            public delegate float4x3 OUT_float4x3(float a, float b);

            public delegate float2x4 OUT_float2x4(float a, float b);

            public delegate float3x4 OUT_float3x4(float a, float b);

            public delegate float4x4 OUT_float4x4(float a, float b);

            public delegate double OUT_double(float a, float b);

            public delegate double2 OUT_double2(float a, float b);

            public delegate double3 OUT_double3(float a, float b);

            public delegate double4 OUT_double4(float a, float b);

            public delegate double2x2 OUT_double2x2(float a, float b);

            public delegate double3x2 OUT_double3x2(float a, float b);

            public delegate double4x2 OUT_double4x2(float a, float b);

            public delegate double2x3 OUT_double2x3(float a, float b);

            public delegate double3x3 OUT_double3x3(float a, float b);

            public delegate double4x3 OUT_double4x3(float a, float b);

            public delegate double2x4 OUT_double2x4(float a, float b);

            public delegate double3x4 OUT_double3x4(float a, float b);

            public delegate double4x4 OUT_double4x4(float a, float b);

            public delegate bool OUT_bool(float a, float b);

            public delegate bool2 OUT_bool2(float a, float b);

            public delegate bool3 OUT_bool3(float a, float b);

            public delegate bool4 OUT_bool4(float a, float b);

            public delegate bool2x2 OUT_bool2x2(float a, float b);

            public delegate bool3x2 OUT_bool3x2(float a, float b);

            public delegate bool4x2 OUT_bool4x2(float a, float b);

            public delegate bool2x3 OUT_bool2x3(float a, float b);

            public delegate bool3x3 OUT_bool3x3(float a, float b);

            public delegate bool4x3 OUT_bool4x3(float a, float b);

            public delegate bool2x4 OUT_bool2x4(float a, float b);

            public delegate bool3x4 OUT_bool3x4(float a, float b);

            public delegate bool4x4 OUT_bool4x4(float a, float b);

            public delegate quaternion OUT_quaterinon(float a, float b);
        }

        public static class IN_float_float_float
        {
            public delegate void OUT_void(float a, float b, float c);

            public delegate half OUT_half(float a, float b, float c);

            public delegate half2 OUT_half2(float a, float b, float c);

            public delegate half3 OUT_half3(float a, float b, float c);

            public delegate half4 OUT_half4(float a, float b, float c);

            public delegate int OUT_int(float a, float b, float c);

            public delegate int2 OUT_int2(float a, float b, float c);

            public delegate int3 OUT_int3(float a, float b, float c);

            public delegate int4 OUT_int4(float a, float b, float c);

            public delegate int2x2 OUT_int2x2(float a, float b, float c);

            public delegate int3x2 OUT_int3x2(float a, float b, float c);

            public delegate int4x2 OUT_int4x2(float a, float b, float c);

            public delegate int2x3 OUT_int2x3(float a, float b, float c);

            public delegate int3x3 OUT_int3x3(float a, float b, float c);

            public delegate int4x3 OUT_int4x3(float a, float b, float c);

            public delegate int2x4 OUT_int2x4(float a, float b, float c);

            public delegate int3x4 OUT_int3x4(float a, float b, float c);

            public delegate int4x4 OUT_int4x4(float a, float b, float c);

            public delegate float OUT_float(float a, float b, float c);

            public delegate float2 OUT_float2(float a, float b, float c);

            public delegate float3 OUT_float3(float a, float b, float c);

            public delegate float4 OUT_float4(float a, float b, float c);

            public delegate float2x2 OUT_float2x2(float a, float b, float c);

            public delegate float3x2 OUT_float3x2(float a, float b, float c);

            public delegate float4x2 OUT_float4x2(float a, float b, float c);

            public delegate float2x3 OUT_float2x3(float a, float b, float c);

            public delegate float3x3 OUT_float3x3(float a, float b, float c);

            public delegate float4x3 OUT_float4x3(float a, float b, float c);

            public delegate float2x4 OUT_float2x4(float a, float b, float c);

            public delegate float3x4 OUT_float3x4(float a, float b, float c);

            public delegate float4x4 OUT_float4x4(float a, float b, float c);

            public delegate double OUT_double(float a, float b, float c);

            public delegate double2 OUT_double2(float a, float b, float c);

            public delegate double3 OUT_double3(float a, float b, float c);

            public delegate double4 OUT_double4(float a, float b, float c);

            public delegate double2x2 OUT_double2x2(float a, float b, float c);

            public delegate double3x2 OUT_double3x2(float a, float b, float c);

            public delegate double4x2 OUT_double4x2(float a, float b, float c);

            public delegate double2x3 OUT_double2x3(float a, float b, float c);

            public delegate double3x3 OUT_double3x3(float a, float b, float c);

            public delegate double4x3 OUT_double4x3(float a, float b, float c);

            public delegate double2x4 OUT_double2x4(float a, float b, float c);

            public delegate double3x4 OUT_double3x4(float a, float b, float c);

            public delegate double4x4 OUT_double4x4(float a, float b, float c);

            public delegate bool OUT_bool(float a, float b, float c);

            public delegate bool2 OUT_bool2(float a, float b, float c);

            public delegate bool3 OUT_bool3(float a, float b, float c);

            public delegate bool4 OUT_bool4(float a, float b, float c);

            public delegate bool2x2 OUT_bool2x2(float a, float b, float c);

            public delegate bool3x2 OUT_bool3x2(float a, float b, float c);

            public delegate bool4x2 OUT_bool4x2(float a, float b, float c);

            public delegate bool2x3 OUT_bool2x3(float a, float b, float c);

            public delegate bool3x3 OUT_bool3x3(float a, float b, float c);

            public delegate bool4x3 OUT_bool4x3(float a, float b, float c);

            public delegate bool2x4 OUT_bool2x4(float a, float b, float c);

            public delegate bool3x4 OUT_bool3x4(float a, float b, float c);

            public delegate bool4x4 OUT_bool4x4(float a, float b, float c);

            public delegate quaternion OUT_quaterinon(float a, float b, float c);
        }
        
        public static class IN_double
        {
            public delegate void OUT_void(double a);

            public delegate half OUT_half(double a);

            public delegate half2 OUT_half2(double a);

            public delegate half3 OUT_half3(double a);

            public delegate half4 OUT_half4(double a);

            public delegate int OUT_int(double a);

            public delegate int2 OUT_int2(double a);

            public delegate int3 OUT_int3(double a);

            public delegate int4 OUT_int4(double a);

            public delegate int2x2 OUT_int2x2(double a);

            public delegate int3x2 OUT_int3x2(double a);

            public delegate int4x2 OUT_int4x2(double a);

            public delegate int2x3 OUT_int2x3(double a);

            public delegate int3x3 OUT_int3x3(double a);

            public delegate int4x3 OUT_int4x3(double a);

            public delegate int2x4 OUT_int2x4(double a);

            public delegate int3x4 OUT_int3x4(double a);

            public delegate int4x4 OUT_int4x4(double a);

            public delegate float OUT_float(double a);

            public delegate float2 OUT_float2(double a);

            public delegate float3 OUT_float3(double a);

            public delegate float4 OUT_float4(double a);

            public delegate float2x2 OUT_float2x2(double a);

            public delegate float3x2 OUT_float3x2(double a);

            public delegate float4x2 OUT_float4x2(double a);

            public delegate float2x3 OUT_float2x3(double a);

            public delegate float3x3 OUT_float3x3(double a);

            public delegate float4x3 OUT_float4x3(double a);

            public delegate float2x4 OUT_float2x4(double a);

            public delegate float3x4 OUT_float3x4(double a);

            public delegate float4x4 OUT_float4x4(double a);

            public delegate double OUT_double(double a);

            public delegate double2 OUT_double2(double a);

            public delegate double3 OUT_double3(double a);

            public delegate double4 OUT_double4(double a);

            public delegate double2x2 OUT_double2x2(double a);

            public delegate double3x2 OUT_double3x2(double a);

            public delegate double4x2 OUT_double4x2(double a);

            public delegate double2x3 OUT_double2x3(double a);

            public delegate double3x3 OUT_double3x3(double a);

            public delegate double4x3 OUT_double4x3(double a);

            public delegate double2x4 OUT_double2x4(double a);

            public delegate double3x4 OUT_double3x4(double a);

            public delegate double4x4 OUT_double4x4(double a);

            public delegate bool OUT_bool(double a);

            public delegate bool2 OUT_bool2(double a);

            public delegate bool3 OUT_bool3(double a);

            public delegate bool4 OUT_bool4(double a);

            public delegate bool2x2 OUT_bool2x2(double a);

            public delegate bool3x2 OUT_bool3x2(double a);

            public delegate bool4x2 OUT_bool4x2(double a);

            public delegate bool2x3 OUT_bool2x3(double a);

            public delegate bool3x3 OUT_bool3x3(double a);

            public delegate bool4x3 OUT_bool4x3(double a);

            public delegate bool2x4 OUT_bool2x4(double a);

            public delegate bool3x4 OUT_bool3x4(double a);

            public delegate bool4x4 OUT_bool4x4(double a);

            public delegate quaternion OUT_quaterinon(double a);
        }

        public static class IN_double_double
        {
            public delegate void OUT_void(double a, double b);

            public delegate half OUT_half(double a, double b);

            public delegate half2 OUT_half2(double a, double b);

            public delegate half3 OUT_half3(double a, double b);

            public delegate half4 OUT_half4(double a, double b);

            public delegate int OUT_int(double a, double b);

            public delegate int2 OUT_int2(double a, double b);

            public delegate int3 OUT_int3(double a, double b);

            public delegate int4 OUT_int4(double a, double b);

            public delegate int2x2 OUT_int2x2(double a, double b);

            public delegate int3x2 OUT_int3x2(double a, double b);

            public delegate int4x2 OUT_int4x2(double a, double b);

            public delegate int2x3 OUT_int2x3(double a, double b);

            public delegate int3x3 OUT_int3x3(double a, double b);

            public delegate int4x3 OUT_int4x3(double a, double b);

            public delegate int2x4 OUT_int2x4(double a, double b);

            public delegate int3x4 OUT_int3x4(double a, double b);

            public delegate int4x4 OUT_int4x4(double a, double b);

            public delegate float OUT_float(double a, double b);

            public delegate float2 OUT_float2(double a, double b);

            public delegate float3 OUT_float3(double a, double b);

            public delegate float4 OUT_float4(double a, double b);

            public delegate float2x2 OUT_float2x2(double a, double b);

            public delegate float3x2 OUT_float3x2(double a, double b);

            public delegate float4x2 OUT_float4x2(double a, double b);

            public delegate float2x3 OUT_float2x3(double a, double b);

            public delegate float3x3 OUT_float3x3(double a, double b);

            public delegate float4x3 OUT_float4x3(double a, double b);

            public delegate float2x4 OUT_float2x4(double a, double b);

            public delegate float3x4 OUT_float3x4(double a, double b);

            public delegate float4x4 OUT_float4x4(double a, double b);

            public delegate double OUT_double(double a, double b);

            public delegate double2 OUT_double2(double a, double b);

            public delegate double3 OUT_double3(double a, double b);

            public delegate double4 OUT_double4(double a, double b);

            public delegate double2x2 OUT_double2x2(double a, double b);

            public delegate double3x2 OUT_double3x2(double a, double b);

            public delegate double4x2 OUT_double4x2(double a, double b);

            public delegate double2x3 OUT_double2x3(double a, double b);

            public delegate double3x3 OUT_double3x3(double a, double b);

            public delegate double4x3 OUT_double4x3(double a, double b);

            public delegate double2x4 OUT_double2x4(double a, double b);

            public delegate double3x4 OUT_double3x4(double a, double b);

            public delegate double4x4 OUT_double4x4(double a, double b);

            public delegate bool OUT_bool(double a, double b);

            public delegate bool2 OUT_bool2(double a, double b);

            public delegate bool3 OUT_bool3(double a, double b);

            public delegate bool4 OUT_bool4(double a, double b);

            public delegate bool2x2 OUT_bool2x2(double a, double b);

            public delegate bool3x2 OUT_bool3x2(double a, double b);

            public delegate bool4x2 OUT_bool4x2(double a, double b);

            public delegate bool2x3 OUT_bool2x3(double a, double b);

            public delegate bool3x3 OUT_bool3x3(double a, double b);

            public delegate bool4x3 OUT_bool4x3(double a, double b);

            public delegate bool2x4 OUT_bool2x4(double a, double b);

            public delegate bool3x4 OUT_bool3x4(double a, double b);

            public delegate bool4x4 OUT_bool4x4(double a, double b);

            public delegate quaternion OUT_quaterinon(double a, double b);
        }

        public static class IN_double_double_double
        {
            public delegate void OUT_void(double a, double b, double c);

            public delegate half OUT_half(double a, double b, double c);

            public delegate half2 OUT_half2(double a, double b, double c);

            public delegate half3 OUT_half3(double a, double b, double c);

            public delegate half4 OUT_half4(double a, double b, double c);

            public delegate int OUT_int(double a, double b, double c);

            public delegate int2 OUT_int2(double a, double b, double c);

            public delegate int3 OUT_int3(double a, double b, double c);

            public delegate int4 OUT_int4(double a, double b, double c);

            public delegate int2x2 OUT_int2x2(double a, double b, double c);

            public delegate int3x2 OUT_int3x2(double a, double b, double c);

            public delegate int4x2 OUT_int4x2(double a, double b, double c);

            public delegate int2x3 OUT_int2x3(double a, double b, double c);

            public delegate int3x3 OUT_int3x3(double a, double b, double c);

            public delegate int4x3 OUT_int4x3(double a, double b, double c);

            public delegate int2x4 OUT_int2x4(double a, double b, double c);

            public delegate int3x4 OUT_int3x4(double a, double b, double c);

            public delegate int4x4 OUT_int4x4(double a, double b, double c);

            public delegate float OUT_float(double a, double b, double c);

            public delegate float2 OUT_float2(double a, double b, double c);

            public delegate float3 OUT_float3(double a, double b, double c);

            public delegate float4 OUT_float4(double a, double b, double c);

            public delegate float2x2 OUT_float2x2(double a, double b, double c);

            public delegate float3x2 OUT_float3x2(double a, double b, double c);

            public delegate float4x2 OUT_float4x2(double a, double b, double c);

            public delegate float2x3 OUT_float2x3(double a, double b, double c);

            public delegate float3x3 OUT_float3x3(double a, double b, double c);

            public delegate float4x3 OUT_float4x3(double a, double b, double c);

            public delegate float2x4 OUT_float2x4(double a, double b, double c);

            public delegate float3x4 OUT_float3x4(double a, double b, double c);

            public delegate float4x4 OUT_float4x4(double a, double b, double c);

            public delegate double OUT_double(double a, double b, double c);

            public delegate double2 OUT_double2(double a, double b, double c);

            public delegate double3 OUT_double3(double a, double b, double c);

            public delegate double4 OUT_double4(double a, double b, double c);

            public delegate double2x2 OUT_double2x2(double a, double b, double c);

            public delegate double3x2 OUT_double3x2(double a, double b, double c);

            public delegate double4x2 OUT_double4x2(double a, double b, double c);

            public delegate double2x3 OUT_double2x3(double a, double b, double c);

            public delegate double3x3 OUT_double3x3(double a, double b, double c);

            public delegate double4x3 OUT_double4x3(double a, double b, double c);

            public delegate double2x4 OUT_double2x4(double a, double b, double c);

            public delegate double3x4 OUT_double3x4(double a, double b, double c);

            public delegate double4x4 OUT_double4x4(double a, double b, double c);

            public delegate bool OUT_bool(double a, double b, double c);

            public delegate bool2 OUT_bool2(double a, double b, double c);

            public delegate bool3 OUT_bool3(double a, double b, double c);

            public delegate bool4 OUT_bool4(double a, double b, double c);

            public delegate bool2x2 OUT_bool2x2(double a, double b, double c);

            public delegate bool3x2 OUT_bool3x2(double a, double b, double c);

            public delegate bool4x2 OUT_bool4x2(double a, double b, double c);

            public delegate bool2x3 OUT_bool2x3(double a, double b, double c);

            public delegate bool3x3 OUT_bool3x3(double a, double b, double c);

            public delegate bool4x3 OUT_bool4x3(double a, double b, double c);

            public delegate bool2x4 OUT_bool2x4(double a, double b, double c);

            public delegate bool3x4 OUT_bool3x4(double a, double b, double c);

            public delegate bool4x4 OUT_bool4x4(double a, double b, double c);

            public delegate quaternion OUT_quaterinon(double a, double b, double c);
        }
        
        public static class IN_float2
        {
            public delegate void OUT_void(float2 a);

            public delegate half OUT_half(float2 a);

            public delegate half2 OUT_half2(float2 a);

            public delegate half3 OUT_half3(float2 a);

            public delegate half4 OUT_half4(float2 a);

            public delegate int OUT_int(float2 a);

            public delegate int2 OUT_int2(float2 a);

            public delegate int3 OUT_int3(float2 a);

            public delegate int4 OUT_int4(float2 a);

            public delegate int2x2 OUT_int2x2(float2 a);

            public delegate int3x2 OUT_int3x2(float2 a);

            public delegate int4x2 OUT_int4x2(float2 a);

            public delegate int2x3 OUT_int2x3(float2 a);

            public delegate int3x3 OUT_int3x3(float2 a);

            public delegate int4x3 OUT_int4x3(float2 a);

            public delegate int2x4 OUT_int2x4(float2 a);

            public delegate int3x4 OUT_int3x4(float2 a);

            public delegate int4x4 OUT_int4x4(float2 a);

            public delegate float OUT_float(float2 a);

            public delegate float2 OUT_float2(float2 a);

            public delegate float3 OUT_float3(float2 a);

            public delegate float4 OUT_float4(float2 a);

            public delegate float2x2 OUT_float2x2(float2 a);

            public delegate float3x2 OUT_float3x2(float2 a);

            public delegate float4x2 OUT_float4x2(float2 a);

            public delegate float2x3 OUT_float2x3(float2 a);

            public delegate float3x3 OUT_float3x3(float2 a);

            public delegate float4x3 OUT_float4x3(float2 a);

            public delegate float2x4 OUT_float2x4(float2 a);

            public delegate float3x4 OUT_float3x4(float2 a);

            public delegate float4x4 OUT_float4x4(float2 a);

            public delegate double OUT_double(float2 a);

            public delegate double2 OUT_double2(float2 a);

            public delegate double3 OUT_double3(float2 a);

            public delegate double4 OUT_double4(float2 a);

            public delegate double2x2 OUT_double2x2(float2 a);

            public delegate double3x2 OUT_double3x2(float2 a);

            public delegate double4x2 OUT_double4x2(float2 a);

            public delegate double2x3 OUT_double2x3(float2 a);

            public delegate double3x3 OUT_double3x3(float2 a);

            public delegate double4x3 OUT_double4x3(float2 a);

            public delegate double2x4 OUT_double2x4(float2 a);

            public delegate double3x4 OUT_double3x4(float2 a);

            public delegate double4x4 OUT_double4x4(float2 a);

            public delegate bool OUT_bool(float2 a);

            public delegate bool2 OUT_bool2(float2 a);

            public delegate bool3 OUT_bool3(float2 a);

            public delegate bool4 OUT_bool4(float2 a);

            public delegate bool2x2 OUT_bool2x2(float2 a);

            public delegate bool3x2 OUT_bool3x2(float2 a);

            public delegate bool4x2 OUT_bool4x2(float2 a);

            public delegate bool2x3 OUT_bool2x3(float2 a);

            public delegate bool3x3 OUT_bool3x3(float2 a);

            public delegate bool4x3 OUT_bool4x3(float2 a);

            public delegate bool2x4 OUT_bool2x4(float2 a);

            public delegate bool3x4 OUT_bool3x4(float2 a);

            public delegate bool4x4 OUT_bool4x4(float2 a);

            public delegate quaternion OUT_quaterinon(float2 a);
        }

        public static class IN_float3
        {
            public delegate void OUT_void(float3 a);

            public delegate half OUT_half(float3 a);

            public delegate half2 OUT_half2(float3 a);

            public delegate half3 OUT_half3(float3 a);

            public delegate half4 OUT_half4(float3 a);

            public delegate int OUT_int(float3 a);

            public delegate int2 OUT_int2(float3 a);

            public delegate int3 OUT_int3(float3 a);

            public delegate int4 OUT_int4(float3 a);

            public delegate int2x2 OUT_int2x2(float3 a);

            public delegate int3x2 OUT_int3x2(float3 a);

            public delegate int4x2 OUT_int4x2(float3 a);

            public delegate int2x3 OUT_int2x3(float3 a);

            public delegate int3x3 OUT_int3x3(float3 a);

            public delegate int4x3 OUT_int4x3(float3 a);

            public delegate int2x4 OUT_int2x4(float3 a);

            public delegate int3x4 OUT_int3x4(float3 a);

            public delegate int4x4 OUT_int4x4(float3 a);

            public delegate float OUT_float(float3 a);

            public delegate float2 OUT_float2(float3 a);

            public delegate float3 OUT_float3(float3 a);

            public delegate float4 OUT_float4(float3 a);

            public delegate float2x2 OUT_float2x2(float3 a);

            public delegate float3x2 OUT_float3x2(float3 a);

            public delegate float4x2 OUT_float4x2(float3 a);

            public delegate float2x3 OUT_float2x3(float3 a);

            public delegate float3x3 OUT_float3x3(float3 a);

            public delegate float4x3 OUT_float4x3(float3 a);

            public delegate float2x4 OUT_float2x4(float3 a);

            public delegate float3x4 OUT_float3x4(float3 a);

            public delegate float4x4 OUT_float4x4(float3 a);

            public delegate double OUT_double(float3 a);

            public delegate double2 OUT_double2(float3 a);

            public delegate double3 OUT_double3(float3 a);

            public delegate double4 OUT_double4(float3 a);

            public delegate double2x2 OUT_double2x2(float3 a);

            public delegate double3x2 OUT_double3x2(float3 a);

            public delegate double4x2 OUT_double4x2(float3 a);

            public delegate double2x3 OUT_double2x3(float3 a);

            public delegate double3x3 OUT_double3x3(float3 a);

            public delegate double4x3 OUT_double4x3(float3 a);

            public delegate double2x4 OUT_double2x4(float3 a);

            public delegate double3x4 OUT_double3x4(float3 a);

            public delegate double4x4 OUT_double4x4(float3 a);

            public delegate bool OUT_bool(float3 a);

            public delegate bool2 OUT_bool2(float3 a);

            public delegate bool3 OUT_bool3(float3 a);

            public delegate bool4 OUT_bool4(float3 a);

            public delegate bool2x2 OUT_bool2x2(float3 a);

            public delegate bool3x2 OUT_bool3x2(float3 a);

            public delegate bool4x2 OUT_bool4x2(float3 a);

            public delegate bool2x3 OUT_bool2x3(float3 a);

            public delegate bool3x3 OUT_bool3x3(float3 a);

            public delegate bool4x3 OUT_bool4x3(float3 a);

            public delegate bool2x4 OUT_bool2x4(float3 a);

            public delegate bool3x4 OUT_bool3x4(float3 a);

            public delegate bool4x4 OUT_bool4x4(float3 a);

            public delegate quaternion OUT_quaterinon(float3 a);
        }

        public static class IN_float4
        {
            public delegate void OUT_void(float4 a);

            public delegate half OUT_half(float4 a);

            public delegate half2 OUT_half2(float4 a);

            public delegate half3 OUT_half3(float4 a);

            public delegate half4 OUT_half4(float4 a);

            public delegate int OUT_int(float4 a);

            public delegate int2 OUT_int2(float4 a);

            public delegate int3 OUT_int3(float4 a);

            public delegate int4 OUT_int4(float4 a);

            public delegate int2x2 OUT_int2x2(float4 a);

            public delegate int3x2 OUT_int3x2(float4 a);

            public delegate int4x2 OUT_int4x2(float4 a);

            public delegate int2x3 OUT_int2x3(float4 a);

            public delegate int3x3 OUT_int3x3(float4 a);

            public delegate int4x3 OUT_int4x3(float4 a);

            public delegate int2x4 OUT_int2x4(float4 a);

            public delegate int3x4 OUT_int3x4(float4 a);

            public delegate int4x4 OUT_int4x4(float4 a);

            public delegate float OUT_float(float4 a);

            public delegate float2 OUT_float2(float4 a);

            public delegate float3 OUT_float3(float4 a);

            public delegate float4 OUT_float4(float4 a);

            public delegate float2x2 OUT_float2x2(float4 a);

            public delegate float3x2 OUT_float3x2(float4 a);

            public delegate float4x2 OUT_float4x2(float4 a);

            public delegate float2x3 OUT_float2x3(float4 a);

            public delegate float3x3 OUT_float3x3(float4 a);

            public delegate float4x3 OUT_float4x3(float4 a);

            public delegate float2x4 OUT_float2x4(float4 a);

            public delegate float3x4 OUT_float3x4(float4 a);

            public delegate float4x4 OUT_float4x4(float4 a);

            public delegate double OUT_double(float4 a);

            public delegate double2 OUT_double2(float4 a);

            public delegate double3 OUT_double3(float4 a);

            public delegate double4 OUT_double4(float4 a);

            public delegate double2x2 OUT_double2x2(float4 a);

            public delegate double3x2 OUT_double3x2(float4 a);

            public delegate double4x2 OUT_double4x2(float4 a);

            public delegate double2x3 OUT_double2x3(float4 a);

            public delegate double3x3 OUT_double3x3(float4 a);

            public delegate double4x3 OUT_double4x3(float4 a);

            public delegate double2x4 OUT_double2x4(float4 a);

            public delegate double3x4 OUT_double3x4(float4 a);

            public delegate double4x4 OUT_double4x4(float4 a);

            public delegate bool OUT_bool(float4 a);

            public delegate bool2 OUT_bool2(float4 a);

            public delegate bool3 OUT_bool3(float4 a);

            public delegate bool4 OUT_bool4(float4 a);

            public delegate bool2x2 OUT_bool2x2(float4 a);

            public delegate bool3x2 OUT_bool3x2(float4 a);

            public delegate bool4x2 OUT_bool4x2(float4 a);

            public delegate bool2x3 OUT_bool2x3(float4 a);

            public delegate bool3x3 OUT_bool3x3(float4 a);

            public delegate bool4x3 OUT_bool4x3(float4 a);

            public delegate bool2x4 OUT_bool2x4(float4 a);

            public delegate bool3x4 OUT_bool3x4(float4 a);

            public delegate bool4x4 OUT_bool4x4(float4 a);

            public delegate quaternion OUT_quaterinon(float4 a);
        }

        public static class IN_int
        {
            public delegate void OUT_void(int a);

            public delegate half OUT_half(int a);

            public delegate half2 OUT_half2(int a);

            public delegate half3 OUT_half3(int a);

            public delegate half4 OUT_half4(int a);

            public delegate int OUT_int(int a);

            public delegate int2 OUT_int2(int a);

            public delegate int3 OUT_int3(int a);

            public delegate int4 OUT_int4(int a);

            public delegate int2x2 OUT_int2x2(int a);

            public delegate int3x2 OUT_int3x2(int a);

            public delegate int4x2 OUT_int4x2(int a);

            public delegate int2x3 OUT_int2x3(int a);

            public delegate int3x3 OUT_int3x3(int a);

            public delegate int4x3 OUT_int4x3(int a);

            public delegate int2x4 OUT_int2x4(int a);

            public delegate int3x4 OUT_int3x4(int a);

            public delegate int4x4 OUT_int4x4(int a);

            public delegate float OUT_float(int a);

            public delegate float2 OUT_float2(int a);

            public delegate float3 OUT_float3(int a);

            public delegate float4 OUT_float4(int a);

            public delegate float2x2 OUT_float2x2(int a);

            public delegate float3x2 OUT_float3x2(int a);

            public delegate float4x2 OUT_float4x2(int a);

            public delegate float2x3 OUT_float2x3(int a);

            public delegate float3x3 OUT_float3x3(int a);

            public delegate float4x3 OUT_float4x3(int a);

            public delegate float2x4 OUT_float2x4(int a);

            public delegate float3x4 OUT_float3x4(int a);

            public delegate float4x4 OUT_float4x4(int a);

            public delegate double OUT_double(int a);

            public delegate double2 OUT_double2(int a);

            public delegate double3 OUT_double3(int a);

            public delegate double4 OUT_double4(int a);

            public delegate double2x2 OUT_double2x2(int a);

            public delegate double3x2 OUT_double3x2(int a);

            public delegate double4x2 OUT_double4x2(int a);

            public delegate double2x3 OUT_double2x3(int a);

            public delegate double3x3 OUT_double3x3(int a);

            public delegate double4x3 OUT_double4x3(int a);

            public delegate double2x4 OUT_double2x4(int a);

            public delegate double3x4 OUT_double3x4(int a);

            public delegate double4x4 OUT_double4x4(int a);

            public delegate bool OUT_bool(int a);

            public delegate bool2 OUT_bool2(int a);

            public delegate bool3 OUT_bool3(int a);

            public delegate bool4 OUT_bool4(int a);

            public delegate bool2x2 OUT_bool2x2(int a);

            public delegate bool3x2 OUT_bool3x2(int a);

            public delegate bool4x2 OUT_bool4x2(int a);

            public delegate bool2x3 OUT_bool2x3(int a);

            public delegate bool3x3 OUT_bool3x3(int a);

            public delegate bool4x3 OUT_bool4x3(int a);

            public delegate bool2x4 OUT_bool2x4(int a);

            public delegate bool3x4 OUT_bool3x4(int a);

            public delegate bool4x4 OUT_bool4x4(int a);

            public delegate quaternion OUT_quaterinon(int a);
        }

        public static class IN_int2
        {
            public delegate void OUT_void(int2 a);

            public delegate half OUT_half(int2 a);

            public delegate half2 OUT_half2(int2 a);

            public delegate half3 OUT_half3(int2 a);

            public delegate half4 OUT_half4(int2 a);

            public delegate int OUT_int(int2 a);

            public delegate int2 OUT_int2(int2 a);

            public delegate int3 OUT_int3(int2 a);

            public delegate int4 OUT_int4(int2 a);

            public delegate int2x2 OUT_int2x2(int2 a);

            public delegate int3x2 OUT_int3x2(int2 a);

            public delegate int4x2 OUT_int4x2(int2 a);

            public delegate int2x3 OUT_int2x3(int2 a);

            public delegate int3x3 OUT_int3x3(int2 a);

            public delegate int4x3 OUT_int4x3(int2 a);

            public delegate int2x4 OUT_int2x4(int2 a);

            public delegate int3x4 OUT_int3x4(int2 a);

            public delegate int4x4 OUT_int4x4(int2 a);

            public delegate float OUT_float(int2 a);

            public delegate float2 OUT_float2(int2 a);

            public delegate float3 OUT_float3(int2 a);

            public delegate float4 OUT_float4(int2 a);

            public delegate float2x2 OUT_float2x2(int2 a);

            public delegate float3x2 OUT_float3x2(int2 a);

            public delegate float4x2 OUT_float4x2(int2 a);

            public delegate float2x3 OUT_float2x3(int2 a);

            public delegate float3x3 OUT_float3x3(int2 a);

            public delegate float4x3 OUT_float4x3(int2 a);

            public delegate float2x4 OUT_float2x4(int2 a);

            public delegate float3x4 OUT_float3x4(int2 a);

            public delegate float4x4 OUT_float4x4(int2 a);

            public delegate double OUT_double(int2 a);

            public delegate double2 OUT_double2(int2 a);

            public delegate double3 OUT_double3(int2 a);

            public delegate double4 OUT_double4(int2 a);

            public delegate double2x2 OUT_double2x2(int2 a);

            public delegate double3x2 OUT_double3x2(int2 a);

            public delegate double4x2 OUT_double4x2(int2 a);

            public delegate double2x3 OUT_double2x3(int2 a);

            public delegate double3x3 OUT_double3x3(int2 a);

            public delegate double4x3 OUT_double4x3(int2 a);

            public delegate double2x4 OUT_double2x4(int2 a);

            public delegate double3x4 OUT_double3x4(int2 a);

            public delegate double4x4 OUT_double4x4(int2 a);

            public delegate bool OUT_bool(int2 a);

            public delegate bool2 OUT_bool2(int2 a);

            public delegate bool3 OUT_bool3(int2 a);

            public delegate bool4 OUT_bool4(int2 a);

            public delegate bool2x2 OUT_bool2x2(int2 a);

            public delegate bool3x2 OUT_bool3x2(int2 a);

            public delegate bool4x2 OUT_bool4x2(int2 a);

            public delegate bool2x3 OUT_bool2x3(int2 a);

            public delegate bool3x3 OUT_bool3x3(int2 a);

            public delegate bool4x3 OUT_bool4x3(int2 a);

            public delegate bool2x4 OUT_bool2x4(int2 a);

            public delegate bool3x4 OUT_bool3x4(int2 a);

            public delegate bool4x4 OUT_bool4x4(int2 a);

            public delegate quaternion OUT_quaterinon(int2 a);
        }

        public static class IN_int3
        {
            public delegate void OUT_void(int3 a);

            public delegate half OUT_half(int3 a);

            public delegate half2 OUT_half2(int3 a);

            public delegate half3 OUT_half3(int3 a);

            public delegate half4 OUT_half4(int3 a);

            public delegate int OUT_int(int3 a);

            public delegate int2 OUT_int2(int3 a);

            public delegate int3 OUT_int3(int3 a);

            public delegate int4 OUT_int4(int3 a);

            public delegate int2x2 OUT_int2x2(int3 a);

            public delegate int3x2 OUT_int3x2(int3 a);

            public delegate int4x2 OUT_int4x2(int3 a);

            public delegate int2x3 OUT_int2x3(int3 a);

            public delegate int3x3 OUT_int3x3(int3 a);

            public delegate int4x3 OUT_int4x3(int3 a);

            public delegate int2x4 OUT_int2x4(int3 a);

            public delegate int3x4 OUT_int3x4(int3 a);

            public delegate int4x4 OUT_int4x4(int3 a);

            public delegate float OUT_float(int3 a);

            public delegate float2 OUT_float2(int3 a);

            public delegate float3 OUT_float3(int3 a);

            public delegate float4 OUT_float4(int3 a);

            public delegate float2x2 OUT_float2x2(int3 a);

            public delegate float3x2 OUT_float3x2(int3 a);

            public delegate float4x2 OUT_float4x2(int3 a);

            public delegate float2x3 OUT_float2x3(int3 a);

            public delegate float3x3 OUT_float3x3(int3 a);

            public delegate float4x3 OUT_float4x3(int3 a);

            public delegate float2x4 OUT_float2x4(int3 a);

            public delegate float3x4 OUT_float3x4(int3 a);

            public delegate float4x4 OUT_float4x4(int3 a);

            public delegate double OUT_double(int3 a);

            public delegate double2 OUT_double2(int3 a);

            public delegate double3 OUT_double3(int3 a);

            public delegate double4 OUT_double4(int3 a);

            public delegate double2x2 OUT_double2x2(int3 a);

            public delegate double3x2 OUT_double3x2(int3 a);

            public delegate double4x2 OUT_double4x2(int3 a);

            public delegate double2x3 OUT_double2x3(int3 a);

            public delegate double3x3 OUT_double3x3(int3 a);

            public delegate double4x3 OUT_double4x3(int3 a);

            public delegate double2x4 OUT_double2x4(int3 a);

            public delegate double3x4 OUT_double3x4(int3 a);

            public delegate double4x4 OUT_double4x4(int3 a);

            public delegate bool OUT_bool(int3 a);

            public delegate bool2 OUT_bool2(int3 a);

            public delegate bool3 OUT_bool3(int3 a);

            public delegate bool4 OUT_bool4(int3 a);

            public delegate bool2x2 OUT_bool2x2(int3 a);

            public delegate bool3x2 OUT_bool3x2(int3 a);

            public delegate bool4x2 OUT_bool4x2(int3 a);

            public delegate bool2x3 OUT_bool2x3(int3 a);

            public delegate bool3x3 OUT_bool3x3(int3 a);

            public delegate bool4x3 OUT_bool4x3(int3 a);

            public delegate bool2x4 OUT_bool2x4(int3 a);

            public delegate bool3x4 OUT_bool3x4(int3 a);

            public delegate bool4x4 OUT_bool4x4(int3 a);

            public delegate quaternion OUT_quaterinon(int3 a);
        }

        public static class IN_int4
        {
            public delegate void OUT_void(int4 a);

            public delegate half OUT_half(int4 a);

            public delegate half2 OUT_half2(int4 a);

            public delegate half3 OUT_half3(int4 a);

            public delegate half4 OUT_half4(int4 a);

            public delegate int OUT_int(int4 a);

            public delegate int2 OUT_int2(int4 a);

            public delegate int3 OUT_int3(int4 a);

            public delegate int4 OUT_int4(int4 a);

            public delegate int2x2 OUT_int2x2(int4 a);

            public delegate int3x2 OUT_int3x2(int4 a);

            public delegate int4x2 OUT_int4x2(int4 a);

            public delegate int2x3 OUT_int2x3(int4 a);

            public delegate int3x3 OUT_int3x3(int4 a);

            public delegate int4x3 OUT_int4x3(int4 a);

            public delegate int2x4 OUT_int2x4(int4 a);

            public delegate int3x4 OUT_int3x4(int4 a);

            public delegate int4x4 OUT_int4x4(int4 a);

            public delegate float OUT_float(int4 a);

            public delegate float2 OUT_float2(int4 a);

            public delegate float3 OUT_float3(int4 a);

            public delegate float4 OUT_float4(int4 a);

            public delegate float2x2 OUT_float2x2(int4 a);

            public delegate float3x2 OUT_float3x2(int4 a);

            public delegate float4x2 OUT_float4x2(int4 a);

            public delegate float2x3 OUT_float2x3(int4 a);

            public delegate float3x3 OUT_float3x3(int4 a);

            public delegate float4x3 OUT_float4x3(int4 a);

            public delegate float2x4 OUT_float2x4(int4 a);

            public delegate float3x4 OUT_float3x4(int4 a);

            public delegate float4x4 OUT_float4x4(int4 a);

            public delegate double OUT_double(int4 a);

            public delegate double2 OUT_double2(int4 a);

            public delegate double3 OUT_double3(int4 a);

            public delegate double4 OUT_double4(int4 a);

            public delegate double2x2 OUT_double2x2(int4 a);

            public delegate double3x2 OUT_double3x2(int4 a);

            public delegate double4x2 OUT_double4x2(int4 a);

            public delegate double2x3 OUT_double2x3(int4 a);

            public delegate double3x3 OUT_double3x3(int4 a);

            public delegate double4x3 OUT_double4x3(int4 a);

            public delegate double2x4 OUT_double2x4(int4 a);

            public delegate double3x4 OUT_double3x4(int4 a);

            public delegate double4x4 OUT_double4x4(int4 a);

            public delegate bool OUT_bool(int4 a);

            public delegate bool2 OUT_bool2(int4 a);

            public delegate bool3 OUT_bool3(int4 a);

            public delegate bool4 OUT_bool4(int4 a);

            public delegate bool2x2 OUT_bool2x2(int4 a);

            public delegate bool3x2 OUT_bool3x2(int4 a);

            public delegate bool4x2 OUT_bool4x2(int4 a);

            public delegate bool2x3 OUT_bool2x3(int4 a);

            public delegate bool3x3 OUT_bool3x3(int4 a);

            public delegate bool4x3 OUT_bool4x3(int4 a);

            public delegate bool2x4 OUT_bool2x4(int4 a);

            public delegate bool3x4 OUT_bool3x4(int4 a);

            public delegate bool4x4 OUT_bool4x4(int4 a);

            public delegate quaternion OUT_quaterinon(int4 a);
        }


    }
}*/


